
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UserPositionMap
// 创建者：名字 (cc)
// 创建时间：2020/9/26 15:51:00
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
    public class UserPositionMap : IEntityTypeConfiguration<UserPosition>
    {
        public void Configure(EntityTypeBuilder<UserPosition> builder)
        {
            builder.ToTable(nameof(UserPosition));
            builder.HasKey(c => c.PID);
            builder.Property(c => c.PositionCode).HasColumnType("nvarchar(50)").HasMaxLength(20).IsRequired(true);
            builder.Property(c => c.PositionName).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.UserID).HasColumnType("bigint").IsRequired(true);

            builder.Property(c => c.CreateBy).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(c => c.CreateTime).HasColumnType("datetime");
            builder.Property(c => c.UpdateBy).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(c => c.UpdateTime).HasColumnType("datetime");
        }
    }
}
