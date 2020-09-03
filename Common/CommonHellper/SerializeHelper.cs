
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：SerializeHelper
// 创建者：名字 (cc)
// 创建时间：2020/9/3 23:10:27
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


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.CommonHellper
{
    /// <summary>
    /// 扩展方法帮助类
    /// </summary>
    public static class SerializeHelper
    {
        /// <summary>
        /// 将json转化为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson);
        }
    }
}
