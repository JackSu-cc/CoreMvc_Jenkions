using Common.Cmds;
using Common.Events;
using Common.IService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 13:29:59
 * 说    明：
*******************************************************/

namespace Common.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="rabbitMQClient"></param>
        public MediatorService(IMediator mediator)//
        {
            this._mediator = mediator;
        }
        public Task Publish<T>(T @event, string eventPurpose = "简单描述一下此事件的目的!") where T : Event
        {
            //如果需要,后续 可以对事件进行记录,
            //事件中所发送的通知可以不进行记录,

            return _mediator.Publish(@event);
        }

        /// <summary>
        /// 无返回值命令
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public Task Send<T>(T cmd) where T : Command
        {
            return this._mediator.Send(cmd);
        }

        /// <summary>
        /// bool返回值命令
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public Task<TR> Send<T, TR>(T cmd) where T : Command<TR>
        {
            return this._mediator.Send(cmd);
        }

        /// <summary>
        /// string返回值命令
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public Task<string> SendWithReturn<T>(T cmd) where T : CommandWithReturn
        {
            return this._mediator.Send(cmd);
        }
    }
}
