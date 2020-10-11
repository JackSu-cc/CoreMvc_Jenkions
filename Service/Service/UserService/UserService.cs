
//******************************************************************/
// Copyright (C) 2020 All Rights Reserved.
// CLR版本：4.0.30319.42000
// 版本号：V1.0.0
// 文件名：UserService
// 创建者：名字 (cc)
// 创建时间：2020/7/12 15:37:13
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


using Application.IService.IUserService;
using Application.ViewModel;
using Common.BaseInterfaces.IBaseRepository;
using Common.IService;
using Domain.Cmds;
using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediatorService _mediator;
        public UserService(
            IUserRepository userRepository,
            IMediatorService mediator)
        {
            this._userRepository = userRepository;
            this._mediator = mediator;
        }

        public void Test1()
        {
            _userRepository.Test1();
        }


        /// <summary>
        /// 根据主键ID查找用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserInfoVM FindUserInfo(long Id)
        {

            var model = _userRepository.Find(Id);
            if (model != null)
            {
                return new UserInfoVM()
                {
                    ID = model.ID,
                    UserCode = model.UserCode,
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };
            }
            return null; 
        }

        public async Task AddUser(UserInfoVM user)
        {
            AddUserCommand userInfo = new AddUserCommand()
            {
                CreateBy = "cc",
                Email = user.Email,
                UserCode = user.UserCode,
                UserName = user.UserName,
                Password = user.Password
            };

            await this._mediator.Send<AddUserCommand>(userInfo);
        }
    }
}
