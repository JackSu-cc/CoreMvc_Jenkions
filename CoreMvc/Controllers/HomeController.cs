using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreMvc.Models;
using Application.IService.IUserService;
using Application.ViewModel;

namespace CoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class AAA
        { 
           public decimal cc1 { get; set; }
        }

        public IActionResult Index()
        {
            AAA aAA = new AAA() { cc1 = (decimal)2.325912 };

          var ddd=  aAA.cc1.ToString("f2");

            var dd2 = Math.Round(aAA.cc1,2);

            var dd3 = String.Format("{0:N2}",aAA.cc1);
            
            return View();
        }

        public void Add()
        {
            UserInfoVM user = new UserInfoVM()
            {
                UserCode = "cc",
                UserName = "cc",
                Email = "929013002@qq.com",
                Password = "kong23.cncncn"
            };

           // _userService.AddUser(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
