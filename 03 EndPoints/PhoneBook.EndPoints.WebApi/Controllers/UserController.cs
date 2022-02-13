using AutoMapper;
using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.EndPoints.WebApi.Controllers;
using FrameWork.EndPoints.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Domain.Users.Commands;
using PhoneBook.Core.Domain.Users.Dtos;
using PhoneBook.EndPoints.WebApi.Models.Users;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseCommandAPIController
    {
        private readonly IMapper mapper;

        public UserController(CommandDispatcher commandDispatcher, CommandRequestHandler requestHandler,IMapper mapper) : base(commandDispatcher, requestHandler)
        {
            this.mapper = mapper;
        }

 
        [HttpPost("UserLogin")]
        public async Task<IActionResult> Login([FromBody]UserLoginModel model)
        {
            var command = mapper.Map<AddUserLoginHistoryCommand>(model);
            command.ClientIPAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
               
            return requestHandler.HandleRequest(command, commandDispatcher.Dispatch<UserLoginHitoryAddResultDto>);
        }
    }
}
