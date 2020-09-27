using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.IUserService
{
    public interface IUserService
    {

        void Test1();


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
        Task AddUser(UserInfoVM user);

    }
}
