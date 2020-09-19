using Common.Cmds;
using System;
using System.Collections.Generic;
using System.Text;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 14:51:37
 * 说    明：
*******************************************************/

namespace Domain.Cmds
{
    /// <summary>
    /// 
    /// </summary>
    public class AddUserCommand : Command
    {
        public override bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// 用户Code
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
    }
}
