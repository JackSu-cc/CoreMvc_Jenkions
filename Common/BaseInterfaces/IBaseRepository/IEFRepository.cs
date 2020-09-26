using Common.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BaseInterfaces.IBaseRepository.IRepository
{
    public interface IEFRepository<TEntity> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id">聚合根主键ID</param>
        /// <returns></returns>
        TEntity Find(long id);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(List<TEntity> entities);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(List<TEntity> entities);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(List<TEntity> entities);

    }
}
