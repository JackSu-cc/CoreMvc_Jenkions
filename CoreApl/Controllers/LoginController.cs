using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.CommonHellper.Ext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApl.Controllers
{
    /// <summary>
    /// 登录服务
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        public readonly JwtSettings _jwtSettings;
        public LoginController(IOptions<JwtSettings> jwtSettings)
        {
            this._jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetToken()
        {
            //定义许多种的声明Claim,信息存储部分,Claims的实体一般包含用户和一些元数据
            IEnumerable<Claim> claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,"cc"),
            };

            //生效时间
            var notBefore = DateTime.UtcNow;
            //过期时间
            var expire = DateTime.UtcNow.AddSeconds(1000);

            //对称秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            //签名证书(秘钥，加密算法)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //生成token  [注意]需要nuget添加Microsoft.AspNetCore.Authentication.JwtBearer包，并引用System.IdentityModel.Tokens.Jwt命名空间
            var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, notBefore, expire, creds);
            return Ok(new CusResult()
            {
                code = 200,
                data = new
                {
                    access_token = new JwtSecurityTokenHandler().WriteToken(token),
                    token_type = "Bearer"
                }
            });
        }


        /// <summary>
        /// sssa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        } 
    }
}
