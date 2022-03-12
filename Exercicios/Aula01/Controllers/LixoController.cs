using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.Controllers
{
    public class LixoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
