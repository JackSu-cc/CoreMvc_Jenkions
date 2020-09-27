//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UserInfo
// 创建者：名字 (cc)
// 创建时间：2020/6/26 16:57:18
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
using Common.BaseInterfaces;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : IAggregateRoot, ICreate, IUpdate
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

        /// <summary>
        /// 用户部门
        /// </summary>
        public virtual List<UserPosition> UserPositions { get; set; }

        #region 基础
        /// <summary>
        /// 有效标识（0;无效；1：有效）
        /// </summary>
        public int ActiveFlag { get; set; }


        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        #endregion
    }
}
