
using Common.Cmds;
using Common.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 13:22:37
 * 说    明：
*******************************************************/

namespace Common.IService
{
    /// <summary>
    /// 
    /// </summary>
  public  interface IMediatorService
    {
        /// <summary>
        /// 命令的统一发送
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task Send<T>(T cmd) where T : Command;


        /// <summary>
        /// 有泛型返回值的命令方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<TR> Send<T, TR>(T cmd) where T : Command<TR>;


        /// <summary>
        /// 此方法不建议使用，请使用通用的有返回值的泛型方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task<string> SendWithReturn<T>(T cmd) where T : CommandWithReturn;


        /// <summary>
        /// 事件的统一发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        /// <param name="eventPurpose">此事件的目的,用于后续进行相关的记录</param>
        /// <returns></returns>
        Task Publish<T>(T @event, string eventPurpose = "简单描述一下此事件的目的!") where T : Event;
    }
}
