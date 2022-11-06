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
        [Route("cadastrar")]
        public IActionResult CadastrarIngressos()
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
