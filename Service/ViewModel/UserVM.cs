
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UserVM
// 创建者：名字 (cc)
// 创建时间：2020/7/12 15:33:55
//
// 描述：
//
// 
//=================================================================
// 修改人：
// 时间：
// 修改说明：
// 
//******************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel
{
    public class UserInfoVM
    { 
        public long ID { get; set; }

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

    }
}
