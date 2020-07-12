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
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);


    }
}
