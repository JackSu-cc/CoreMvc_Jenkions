using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 13:13:26
 * 说    明：
*******************************************************/

namespace Common.Cmds
{
    /// <summary>
    /// 无返回值类型
    /// 命令模型基类，用于处理 CUD操作的验证处理逻辑 ，查询逻辑 则直接走仓储去处理
    /// </summary>
    public abstract class Command : IRequest
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
        /// <summary>
        /// 此对象用于统一承载 子类实体验证后的结果
        /// </summary>
        //public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// 此方法用于验证子类中的属性是否满足条件
        /// 需要在各子类中单独实现
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();
    }

    /// <summary>
    /// 有返回值类型
    /// 通用的命令模型基类
    /// </summary>
    public abstract class Command<T> : IRequest<T>
    {
        public DateTime Timestamp { get; private set; }
        public Command()
        {
            Timestamp = DateTime.Now;
        }
        /// <summary>
        /// 此对象用于统一承载 子类实体验证后的结果
        /// </summary>
        //public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// 此方法用于验证子类中的属性是否满足条件
        /// 需要在各子类中单独实现
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();
    }


    /// <summary>
    /// 有返回值，且返回值是string类型
    /// 命令模型基类，用于处理 CUD操作的验证处理逻辑 ，查询逻辑 则直接走仓储去处理
    /// </summary>
    public abstract class CommandWithReturn : IRequest<string>
    {
        public DateTime Timestamp { get; private set; }

        public CommandWithReturn()
        {
            Timestamp = DateTime.Now;
        }
        /// <summary>
        /// 此对象用于统一承载 子类实体验证后的结果
        /// </summary>
        //public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// 此方法用于验证子类中的属性是否满足条件
        /// 需要在各子类中单独实现
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();
    }
}
