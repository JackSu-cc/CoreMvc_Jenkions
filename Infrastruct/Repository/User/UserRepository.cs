
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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastruct.Repository.User
{
    public class UserRepository : EFRepository<UserInfo>, IUserRepository
    {
        private readonly CoreDemoDBContext _context;
        public UserRepository(CoreDemoDBContext context) : base(context)
        {
            this._context = context;
        }
         
        public void Test1()
        {
            long[] aa = {1,3,4,5 }; 

            var dd4 = _dbContext.UserInfo.Where(c => aa.Contains(c.ID)).ToList();
            var dd5 = _dbContext.UserInfo.Find();
            var dd6 = _dbSet;


            var tts1 = _dbContext.UserInfo.Where(c => EF.Functions.Like(c.UserName, "%风%")).ToList();

            var rrr = _dbContext.UserInfo.Where(c => EF.Functions.Like(c.UserName, "%风%")).ToList();

            _dbContext.UserInfo.Where(c => c.UserCode == "lixl").AsEnumerable();

            var tt2 = _dbContext.UserInfo.Where(c => c.UserCode == "lixl").AsEnumerable();

            var dds = tt2.FirstOrDefault().UserPositions.FirstOrDefault().PositionName;

            var tt3 = _dbContext.UserInfo.Where(c => c.UserCode == "lixl").AsEnumerable().Select(c => c.UserName);

            var tt5 = _dbContext.UserInfo.Where(c => c.UserCode == "lixl").Select(c => new
            {
                c.UserName,
                c.UpdateBy,
                c.UserPositions
            }).AsEnumerable();


            _dbContext.UserInfo.Where(c => c.UserCode == "lixl").AsQueryable();

            var tt4 = _dbContext.UserInfo.Where(c => c.UserCode == "lixl").AsQueryable();

        }
    }
}
