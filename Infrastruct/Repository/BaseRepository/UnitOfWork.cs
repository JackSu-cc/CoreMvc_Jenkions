
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UnitOfWork
// 创建者：名字 (cc)
// 创建时间：2020/7/8 23:11:50
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


using Common.BaseInterfaces.IBaseRepository;
using Infrastruct.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Repository.BaseRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private readonly CoreDemoDBContext _dbcontext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(CoreDemoDBContext context)
        {
            this._dbcontext = context;
        }


        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            return _dbcontext.SaveChanges() > 0;
        }

        //手动回收
        public void Dispose()
        {
            this._dbcontext.Dispose();
        }
    }
}
