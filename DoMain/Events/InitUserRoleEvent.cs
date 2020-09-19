using Common.Events;
using System;
using System.Collections.Generic;
using System.Text;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 16:50:13
 * 说    明：
*******************************************************/

namespace Domain.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class InitUserRoleEvent : Event
    {
        protected InitUserRoleEventDTO _initUserRole;
        public InitUserRoleEvent(InitUserRoleEventDTO userRoleEventDTO)
        {
            _initUserRole = userRoleEventDTO;

        }
    }

    /// <summary>
    /// 初始化用户角色模型
    /// </summary>
    public class InitUserRoleEventDTO
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 用户Code
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
    }
}
