using Common.Events;
using System;
using System.Collections.Generic;
using System.Text;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 16:18:06
 * 说    明：
*******************************************************/

namespace Common.Notice
{
    /// <summary>
    /// 领域模型中的通知模型统一定义
    /// 领域通知以事件的形式进行处理，走订阅发布的通路 因此 继承  INotification
    /// </summary>
    public class Notification:Event
    {
        /// <summary>
        /// 通知领域标识
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// 通知Key
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// 通知Value
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// 通知的版本
        /// </summary>
        public double Version { get; private set; }

        public Notification(string key, string value, double version = 1.0)
        {
            Id = Guid.NewGuid().ToString("N");
            Key = key;
            Value = value;
            Version = version;
        }
    }
}
