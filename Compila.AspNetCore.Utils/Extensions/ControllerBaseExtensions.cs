using System;

using Compila.Net.Utils.Rest;
using Compila.Net.Utils.ServiceResponses;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compila.AspNetCore.Utils.Extensions
{
    public static class ControllerBaseExtensions
    {
        //TODO: Implement self error details object
        public static IActionResult ProcessError(this ControllerBase controllerBase, ServiceBaseResponse baseResponse)
        {
            return baseResponse switch
            {
                ServiceNotFoundResponse => controllerBase.NotFound(new ErrorDetails
                {
                    Message = ((ServiceNotFoundResponse)baseResponse).Message,
                    StatusCode = StatusCodes.Status404NotFound
                }),
                ServiceBadRequestResponse => controllerBase.BadRequest(new ErrorDetails
                {
                    Message = ((ServiceBadRequestResponse)baseResponse).Message,
                    StatusCode = StatusCodes.Status400BadRequest
                }),
                ServiceInternalServerError => new JsonResult(new ErrorDetails
                {
                    Message = ((ServiceInternalServerError)baseResponse).Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                },
                ServiceErrorResponse => new JsonResult(new ErrorDetails
                {
                    Message = ((ServiceErrorResponse)baseResponse).Message,
                    StatusCode = ((ServiceErrorResponse)baseResponse).ErrorCode
                })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                },
                _ => throw new NotImplementedException()
            };
        }
    }
}
