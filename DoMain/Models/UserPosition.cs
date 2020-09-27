
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UserPosition
// 创建者：名字 (cc)
// 创建时间：2020/9/26 15:43:53
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    /// <summary>
    /// 用户岗位
    /// </summary>
    public class UserPosition : IEntity, ICreate, IUpdate
    {
        [Key]
        public long PID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
       
        public  long UserID { get; set; }
        /// <summary>
        /// 岗位Code
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PositionName { get; set; }


        #region 基础

        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        #endregion

        /// <summary>
        /// 关联
        /// </summary>
        [ForeignKey("UserID")]
        public virtual UserInfo UserInfo { get; set; }
    }
}
