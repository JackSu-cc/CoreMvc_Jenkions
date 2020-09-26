
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：EFRepository
// 创建者：名字 (cc)
// 创建时间：2020/7/2 23:02:23
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
using Common.BaseInterfaces.IBaseRepository.IRepository;
using Infrastruct.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Repository.BaseRepository
{
    public class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        public readonly CoreDemoDBContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;
        public EFRepository(CoreDemoDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// 根据主键ID查询
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public TEntity Find(long id)
        {
            return _dbSet.Find(id);
        }

        #region CRD
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(List<TEntity> entities)
        {
            _dbContext.AddRange(entities);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateRange(List<TEntity> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteRange(List<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
        }

        #endregion
    }
}
