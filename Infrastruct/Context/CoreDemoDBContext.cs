
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：DBContext
// 创建者：名字 (cc)
// 创建时间：2020/6/26 17:37:20
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


using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Context
{
    /// <summary>
    /// DBContext
    /// </summary>
    public class CoreDemoDBContext : DbContext
    {
        public CoreDemoDBContext(DbContextOptions options) : base(options)
        {

        }

        #region 用户相关表

        /// <summary>
        /// 用户信息表
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }

        /// <summary>
        /// 用户岗位
        /// </summary>
        public DbSet<UserPosition> UserPosition { get; set; }


        #endregion




        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //增加延时加载--使用时关联的表增加 virtual关键字
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
