﻿using AutoMapper;
using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.EndPoints.WebApi.Controllers;
using FrameWork.EndPoints.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Domain.Contacts.Commands;
using PhoneBook.EndPoints.WebApi.Models.Contacts;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseCommandAPIController
    {
        private readonly IMapper mapper;

        public ContactController(CommandDispatcher commandDispatcher, CommandRequestHandler requestHandler,IMapper mapper) : base(commandDispatcher, requestHandler)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] ContactRegisterModel model)
        {
            ContactRegisterCommand command = mapper.Map< ContactRegisterCommand >(model);
            //command.ClientIPAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();            
            return requestHandler.HandleRequest(command, commandDispatcher.Dispatch);
        }
    }
}
