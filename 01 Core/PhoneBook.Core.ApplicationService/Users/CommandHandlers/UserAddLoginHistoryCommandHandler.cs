using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.Core.Domain.Data;
using FrameWork.Core.Domain.Enums;
using FrameWork.Utilities.Helpers;
using PhoneBook.Core.Domain.Common.Contracts;
using PhoneBook.Core.Domain.Users.Commands;
using PhoneBook.Core.Domain.Users.Dtos;
using PhoneBook.Core.Domain.Users.Repositories;

namespace PhoneBook.Core.ApplicationService.Users.CommandHandlers
{
    public class UserAddLoginHistoryCommandHandler : CommandHandler<AddUserLoginHistoryCommand, UserLoginHitoryAddResultDto>
    {
        private readonly ICommandUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;        
        private readonly ITokenService tokenService;

        public UserAddLoginHistoryCommandHandler(ICommandUserRepository userRepository,IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;            
            this.tokenService = tokenService;
        }
        public override CommandResult<UserLoginHitoryAddResultDto> Handle(AddUserLoginHistoryCommand command)
        {
            //کنترل موجود بودن کاربر
            var user = userRepository.Load(command.UserName);
            if (user == null)
                return new CommandResult<UserLoginHitoryAddResultDto>(EnuResultStatusCode.NotFound, false, message: "کاربری با این نام کاربری یافت نشد");

            if (user.Password != SecurityHelper.SHA256_Hash(command.Password))
                return new CommandResult<UserLoginHitoryAddResultDto>(EnuResultStatusCode.LogicError, false, message: "کلمه عبور وارد شده نادرست است");

            var tokenResult=tokenService.GenerateToken(new UserTokenDto { UserId = user.Id, UserName = user.UserName, FullName = user.FullName });
            if (!tokenResult.IsSuccess)
                return new CommandResult<UserLoginHitoryAddResultDto>(EnuResultStatusCode.LogicError, false,message: (tokenResult.ErrorMessage ?? "خطایی رخ داده مجدد تلاش کنید"));

            user.AddLoginHistory(command.ClientIPAddress);

            unitOfWork.Commit();

            return new CommandResult<UserLoginHitoryAddResultDto>(EnuResultStatusCode.Success, true, result: new UserLoginHitoryAddResultDto
            {
                AccessToken=tokenResult.Result.Token,
                ExpierDate=tokenResult.Result.ExpireDate
            });
            
        }
    }
}
