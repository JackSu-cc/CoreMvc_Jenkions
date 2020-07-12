
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：ICreate
// 创建者：名字 (cc)
// 创建时间：2020/6/26 17:13:58
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

namespace Common.BaseInterfaces
{
    /// <summary>
    /// 创建接口
    /// </summary>
  public  interface ICreate
    {
        /// <summary>
        /// 创建人
        /// </summary>
        string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        Nullable<DateTime> CreateTime { get; set; }
    }
}
