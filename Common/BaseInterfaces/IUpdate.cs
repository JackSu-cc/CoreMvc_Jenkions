
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：IUpdate
// 创建者：名字 (cc)
// 创建时间：2020/6/26 17:15:58
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
    /// 修改基础接口
    /// </summary>
    public interface IUpdate
    {
        /// <summary>
        /// 修改人
        /// </summary>
        string UpdateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        Nullable<DateTime> UpdateTime { get; set; }

    }
}
