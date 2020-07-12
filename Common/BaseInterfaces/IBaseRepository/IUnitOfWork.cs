
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：IUnitOfWork
// 创建者：名字 (cc)
// 创建时间：2020/7/8 23:10:12
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

namespace Common.BaseInterfaces.IBaseRepository
{
    public interface IUnitOfWork
    {

        bool Commit();
    }
}
