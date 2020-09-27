using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IService.IUserService;
using Application.ViewModel;
using Common.Notice;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApl.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly Noticehandler _noticehandler;

        public UserController(IUserService userService
             , INotificationHandler<Notification> notificationHandler)
        {
            this._userService = userService;
            this._noticehandler = notificationHandler as Noticehandler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            _userService.Test1();


            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddUser(UserInfoVM userInfo)
        {
            await _userService.AddUser(userInfo);

            if (_noticehandler.HasNotification())
            {
                Ok(_noticehandler.GetNotifications());
            }
            return Ok("true");
        }
    }
}
