using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosEBS.Controllers
{
    public class CocineroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ayuda()
        {
            return View();
        }
    }
}