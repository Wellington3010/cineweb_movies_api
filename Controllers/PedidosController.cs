using AutoMapper;
using cineweb_movies_api.DTO;
using cineweb_movies_api.Entities;
using cineweb_movies_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidosController : Controller
    {
        private ClienteBaseRepository<Cliente, int, string> _clientesRepository;
        private PedidoBaseRepository<Pedido, int> _pedidosRepository;
        private readonly FilmeBaseRepository<Filme, Guid> _moviesRepository;
        private readonly IngressoBaseRepository<Ingresso, int, Guid> _ingressoBaseRepository;
        private IMapper _mapper;

        public PedidosController(
            ClienteBaseRepository<Cliente, int, string> clienteRepository,
            FilmeBaseRepository<Filme, Guid> moviesRepository,
            IngressoBaseRepository<Ingresso, int, Guid> ingressoBaseRepository,
            PedidoBaseRepository<Pedido, int> pedidoRepository, IMapper mapper)
        {
            _clientesRepository = clienteRepository;
            _pedidosRepository = pedidoRepository;
            _moviesRepository = moviesRepository;
            _ingressoBaseRepository = ingressoBaseRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarPedido(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            var cliente = await _clientesRepository.FindByCPF(pedidoDTO.CPF);

            if (cliente is not null)
            {
                pedido.IdCliente = cliente.IdCliente;
            }

            if (cliente is null)
            {
                await _clientesRepository.AddItem(new Cliente { CPF = pedidoDTO.CPF, NomeCliente = pedidoDTO.NomeCliente });
                cliente = await _clientesRepository.FindByCPF(pedidoDTO.CPF);
                pedido.IdCliente = cliente.IdCliente;
            }

            await _pedidosRepository.AddItem(pedido);
            var pedidoAtual = _pedidosRepository.FindPedidosByCliente(cliente.IdCliente).Result.Last();
            pedido.Ingressos = new List<IngressoPedido>();

            pedidoDTO.Titulos.ForEach((item) =>
            {
                var filme = _moviesRepository.FindByTitle(item).Result;
                var ingresso = _ingressoBaseRepository.ListarIngressosPorFilme(filme.Id).Result.FirstOrDefault();

                pedido.Ingressos.Add(new IngressoPedido
                {
                    PedidoId = pedidoAtual.Id,
                    Pedido = pedidoAtual,
                    Filme = filme,
                    FilmeId = filme.Id,
                    Ingresso = ingresso,
                    IngressoId = ingresso.IdIngresso
                });
            });

            await _pedidosRepository.Update(pedido);
            return Ok();
        }

        [Route("deletar")]
        public IActionResult DeletarPedido()
        {
            return View();
        }

        [Route("atualizar")]
        public IActionResult AtualizarPedido()
        {
            return View();
        }

        [Route("listar")]
        public async Task<IActionResult> ListarPedidos(int IdUsuario)
        {

            var cliente = await _clientesRepository.FindById(IdUsuario);

            if (cliente is not null)
            {
                return Ok(_mapper.Map<PedidoDTO>(await _pedidosRepository.FindPedidosByCliente(cliente.IdCliente)));
            }

            return BadRequest();
        }
    }
}
