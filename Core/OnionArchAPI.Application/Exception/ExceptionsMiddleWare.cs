using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Exception
{
    public class ExceptionsMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
               await next(httpContext);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
          
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, System.Exception exception)
        {
            int statusCode = StatusCode(exception);
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            List<string> errors = new() {
            exception.Message
            };



            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Error = exception.Message,
                StatusCode = statusCode

            }));


        }

        private int StatusCode(System.Exception exception) 
        {
        
            return exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError

            };
        }


    }
}
