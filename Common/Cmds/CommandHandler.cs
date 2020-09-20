using Common.BaseInterfaces.IBaseRepository;
using Common.IService;
using System;
using System.Collections.Generic;
using System.Text;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 13:19:29
 * 说    明：
*******************************************************/

namespace Common.Cmds
{
    /// <summary>
    /// 命令处理模型基类
    /// </summary>
    public class CommandHandler
    {
        public readonly IUnitOfWork _uow;
        public readonly IMediatorService _mediator;
        public CommandHandler(IUnitOfWork unitOfWork, IMediatorService mediator)
        {
            this._uow = unitOfWork;
            this._mediator = mediator;
        }
         /// <summary>
        /// 以工作单元的模式 对请求进行批量提交
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            //try
            //{
                return _uow.Commit(); 
            //}
            //catch (Exception e)
            //{
            //    this._mediator.Publish(new Notification("", e.ToString()));
            //    throw;
            //}
        }

        /// <summary>
        /// 针对请求中所传递参数验证不通过的情况
        /// 进行通知发布
        /// </summary>
        /// <param name="command"></param>
        protected void NotifyValidations(Command command)
        {
            //foreach (var item in command.ValidationResult.Errors)
            //{
            //    this._mediator.Publish(new Notification("", item.ErrorMessage));
            //}
        }
    }
}
