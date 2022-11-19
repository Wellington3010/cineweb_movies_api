using AutoMapper;
using cineweb_movies_api.DTO;
using cineweb_movies_api.Entities;
using cineweb_movies_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cineweb_movies_api.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidosController : Controller
    {
        private BaseRepository<Cliente, int> _clientesRepository;
        private PedidoBaseRepository<Pedido, int> _pedidosRepository;
        private IMapper _mapper;
        
        public PedidosController(BaseRepository<Cliente, int> clienteRepository, PedidoBaseRepository<Pedido, int> pedidoRepository, IMapper mapper)
        {
            _clientesRepository = clienteRepository;
            _pedidosRepository = pedidoRepository;
            _mapper = mapper;
        }

        [Route("cadastrar")]
        public async Task<IActionResult> CadastrarPedido(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            var cliente = await _clientesRepository.FindById(pedidoDTO.IdUsuario);

            if(cliente is null)
            {
                await _clientesRepository.AddItem(new Cliente { IdUsuario = pedidoDTO.IdUsuario, NomeCliente = pedidoDTO.NomeCliente });
                var clienteDoPedido =  await _clientesRepository.FindById(pedidoDTO.IdUsuario);
                pedido.IdCliente = clienteDoPedido.IdCliente;
                await _pedidosRepository.AddItem(pedido);
                return Ok();
            }

            pedido.IdCliente = cliente.IdCliente;
            await _pedidosRepository.AddItem(pedido);
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

            if(cliente is not null)
            {
                return Ok(_mapper.Map<PedidoDTO>(await _pedidosRepository.FindPedidosByCliente(cliente.IdCliente)));
            }

            return BadRequest();
        }
    }
}
