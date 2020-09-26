using Common.BaseInterfaces.IBaseRepository.IRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IUserRepository:IEFRepository<UserInfo>
    {
        void Test1();
    }
}
