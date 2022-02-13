using FrameWork.Core.Domain.Enums;
using FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace PhoneBook.EndPoints.WebApi.Infra.ActionFilters
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           if(!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new OkObjectResult(new BaseApiResultModel(statuscode: EnuResultStatusCode.UnAuthorized));
        }
    }
}
