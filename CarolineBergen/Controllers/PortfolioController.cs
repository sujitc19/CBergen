using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarolineBergen.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Illustrations()
        {
            return View();
        }

        public IActionResult GraphicDesign()
        {
            return View();
        }
    }
}