
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UserRepository
// 创建者：名字 (cc)
// 创建时间：2020/7/11 22:15:21
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


using Domain.IRepository;
using Domain.Models;
using Infrastruct.Context;
using Infrastruct.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Repository.User
{
    public class UserRepository : EFRepository<UserInfo>, IUserRepository
    {
        public UserRepository(CoreDemoDBContext context) : base(context)
        {

        }
         
    }
}
