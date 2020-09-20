using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 13:24:39
 * 说    明：
*******************************************************/

namespace Common.Events
{
    /// <summary>
    /// 事件统一父类
    /// </summary>
    public abstract class Event : INotification
    {
        /// <summary>
        /// 通知的时间戳
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 事件Id
        /// </summary>
        public long EventId { get { return long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")); } }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
