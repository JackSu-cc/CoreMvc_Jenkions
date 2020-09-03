
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：JwtSettings
// 创建者：名字 (cc)
// 创建时间：2020/9/3 21:42:07
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
    public class JwtSettings
    {
        /// <summary>
        /// token的颁发人
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// token可以给哪些客户端使用
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 加密的key
        /// </summary>
        public string SecretKey { get; set; }
    }
}
