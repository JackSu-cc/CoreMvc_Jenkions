using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 16:17:34
 * 说    明：
*******************************************************/
 
namespace Common.Notice
{
    /// <summary>
    ///领域通知 统一处理
    ///此类中会将当前会话中所产生的异常进行统一处理 并临时存储、处理
    /// </summary>
    public class Noticehandler : INotificationHandler<Notification>
    {
        /// <summary>
        /// 消息内存存储容器
        /// </summary>
        private List<Notification> _notifications = null;
        public Noticehandler()
        {
            _notifications = new List<Notification>();
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取所有的消息
        /// </summary>
        /// <returns></returns>
        public List<Notification> GetNotifications() => _notifications;

        /// <summary>
        /// 判断是否存在消息通知
        /// </summary>
        /// <returns></returns>
        public bool HasNotification() => _notifications.Any();

        /// <summary>
        /// 手动回收（清空通知）
        /// </summary>
        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }



}
