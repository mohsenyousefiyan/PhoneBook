using AutoMapper;
using PhoneBook.Core.Domain.Users.Commands;
using PhoneBook.EndPoints.WebApi.Models.Users;

namespace PhoneBook.EndPoints.WebApi.Infra.MapperConfig
{
    public class UserMappConfig:Profile
    {
        public UserMappConfig()
        {
            CreateMap<UserLoginModel, AddUserLoginHistoryCommand>();
        }
    }
}
