
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

        public DbSet<UserInfo> UserInfos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
             
        //}
    }
}
