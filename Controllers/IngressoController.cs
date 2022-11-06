using cineweb_movies_api.DTO;
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
