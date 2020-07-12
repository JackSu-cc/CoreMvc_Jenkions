using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IService.IUserService
{
    public interface IUserService
    {
        /// <summary>
        /// 根据ID查询用户详情信息
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns></returns>
        UserInfoVM FindUserInfo(long Id);

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AddUser(UserInfoVM user);

    }
}
