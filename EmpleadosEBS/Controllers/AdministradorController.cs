﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosEBS.Controllers
{
    public class AdministradorController : Controller
    {
        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Registrar()
        {
            return View();
        }
    }
}