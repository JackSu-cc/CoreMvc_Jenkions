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
        
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            this._userService = userService;
        }

        public IActionResult Index()
        {
             
            Random dd = new Random();
            
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

            _userService.AddUser(user);
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
