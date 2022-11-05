using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Controllers
{
    public class IngressoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
