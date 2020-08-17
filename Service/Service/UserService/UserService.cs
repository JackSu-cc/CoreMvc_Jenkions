
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
using Domain.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
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

        public bool AddUser(UserInfoVM user)
        {
            UserInfo userInfo = new UserInfo()
            {
                ActiveFlag = 1,
                CreateBy = "cc",
                CreateTime = DateTime.Now,
                Email = user.Email,
                UserCode = user.UserCode,
                UserName = user.UserName,
                Password = user.Password

            };
            _userRepository.Add(userInfo);
            _unitOfWork.Commit();
            
            return true;
        }
    }
}
