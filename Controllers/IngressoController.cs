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
    [Route("ingressos")]
    public class IngressoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IngressoBaseRepository<Ingresso, int, Guid> _ingressoBaseRepository;
        public IngressoController(IMapper mapper, IngressoBaseRepository<Ingresso, int, Guid> ingressoBaseRepository)
        {
            _mapper = mapper;
            _ingressoBaseRepository = ingressoBaseRepository;
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult CadastrarIngressos(IngressoDTO ingressoDTO)
        {
            return View();
        }

        [Route("deletar")]
        public IActionResult DeletarrIngressos()
        {
            return View();
        }

        [Route("atualizar")]
        public IActionResult AtualizarIngressos()
        {
            return View();
        }

        [Route("listar")]
        public IActionResult ListarIngressos()
        {
            return View();
        }
    }
}
