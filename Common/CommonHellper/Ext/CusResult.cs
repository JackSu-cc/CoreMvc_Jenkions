
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：CusResult
// 创建者：名字 (cc)
// 创建时间：2020/9/3 22:01:41
//
// 描述：
//
// 
//=================================================================
// 修改人：
// 时间：
// 修改说明：
// 
//******************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace Common.CommonHellper.Ext
{

    /// <summary>
    /// 自定义返回消息模型
    /// </summary>
   public class CusResult
    {
        /// <summary>
        /// 返回消息编码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 返回的异常消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }

    }
}
