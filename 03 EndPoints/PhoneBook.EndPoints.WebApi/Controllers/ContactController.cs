using AutoMapper;
using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.EndPoints.WebApi.Controllers;
using FrameWork.EndPoints.WebApi.InfraStructures.Extensions;
using FrameWork.EndPoints.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.EndPoints.WebApi.Infra.ActionFilters;
using PhoneBook.EndPoints.WebApi.Models.Contacts;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomAuthorizeAttribute))]
    public class ContactController : BaseCommandAPIController
    {
        private readonly IMapper mapper;

        public ContactController(CommandDispatcher commandDispatcher, CommandRequestHandler requestHandler,IMapper mapper) : base(commandDispatcher, requestHandler)
        {
            this.mapper = mapper;
        }
                     

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] ContactRegisterModel model)
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var userName=HttpContext.User.Identity.GetUserName();
            var userFullName=HttpContext.User.Identity.GetUserLastName();
            ContactRegisterCommand command = mapper.Map< ContactRegisterCommand >(model);           
            return requestHandler.HandleRequest(command, commandDispatcher.Dispatch);
        }

        [HttpPut]
        public async Task<IActionResult> EditContact([FromBody]ContactEditModel model)
        {
            ContactUpdateCommand command = mapper.Map<ContactUpdateCommand>(model);           
            return requestHandler.HandleRequest(command, commandDispatcher.Dispatch);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact([FromQuery]  int id)
        {
            ContactDeleteCommand command =new ContactDeleteCommand { Id = id};  
            return requestHandler.HandleRequest(command, commandDispatcher.Dispatch);
        }
    }
}
