using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Areas.System
{
    [Area("System")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}