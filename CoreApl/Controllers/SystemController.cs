using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApl.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        /// <summary>
        /// eew
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Adsa()
        {
           return Ok("aaas");
        }
    }
}