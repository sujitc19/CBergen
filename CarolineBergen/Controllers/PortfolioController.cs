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

        public IActionResult illustrations()
        {
            return View();
        }

        public IActionResult graphicDesign()
        {
            return View();
        }

        public IActionResult traditional()
        {
            return View();
        }

        public IActionResult comics()
        {
            return View();
        }

        public IActionResult gridderDemo()
        {
            return View();
        }
    }
}