using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 16:50:35
 * 说    明：
*******************************************************/

namespace Domain.EventHandler
{
    /// <summary>
    ///  发送领域事件
    /// </summary>
    public class InitUserRoleEventHandler : INotificationHandler<InitUserRoleEvent>
    {
        /// <summary>
        /// 抛送事件方法
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(InitUserRoleEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
