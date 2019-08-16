using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpleadosEBS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnASPNETCoreMVCWithRealApps.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            Plato productModel = new Plato();
            ViewBag.products = productModel.findAll();
            return View();
        }
    }
}