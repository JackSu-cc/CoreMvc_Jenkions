
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UserMap
// 创建者：名字 (cc)
// 创建时间：2020/6/26 16:54:59
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
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Mappings.UserMap
{
    public class UserMap : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable(nameof(UserInfo));  
            builder.HasKey(c => c.ID);
            builder.Property(c => c.UserCode).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.UserName).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(c => c.Password).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired(true);

            builder.Property(c => c.ActiveFlag).HasColumnType("int").IsRequired(true);
            builder.Property(c => c.CreateBy).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(c => c.CreateTime).HasColumnType("datetime");
            builder.Property(c => c.UpdateBy).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(c => c.UpdateTime).HasColumnType("datetime");

            //一对多关系 
            builder.HasMany(c => c.UserPositions).WithOne(c => c.UserInfo).HasForeignKey(c => c.UserID);
        }
    }
}
