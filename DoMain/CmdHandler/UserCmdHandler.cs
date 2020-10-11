using Common.BaseInterfaces.IBaseRepository;
using Common.Cmds;
using Common.IService;
using Domain.Cmds;
using Domain.IRepository;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Notice;


/******************************************************
 * 公司名称：       Lenovo
 * 创 建 人：       kongdf
 * 创建时间：       2020/9/19 14:53:30
 * 说    明：
*******************************************************/

namespace Domain.CmdHandler
{
    /// <summary>
    /// 用户Handler
    /// </summary>
    public class UserCmdHandler : CommandHandler
        , IRequestHandler<AddUserCommand, Unit>//---AddUserCommand 请求的命令  Unit是返回结果：表示忽略返回结果
    {
        private readonly IUserRepository _userRepository;
        public UserCmdHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMediatorService mediatorService) : base(unitOfWork, mediatorService)
        {
            this._userRepository = userRepository;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            UserInfo userInfo = new UserInfo()
            {
                ActiveFlag = 1,
                CreateBy = request.CreateBy,
                CreateTime = DateTime.Now,
                Email = request.Email,
                UserCode = request.UserCode,
                UserName = request.UserName,
                Password = request.Password

            };
            _userRepository.Add(userInfo);

            if (Commit()) 
            {
                //执行成功后发送事件

            }
            else
            {
                _mediator.Publish(new Notification("","发生异常！"));
            }

            return Task.FromResult(new Unit());
        }
    }
}
