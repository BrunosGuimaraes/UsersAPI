using System.Net;
using UsersAPI.Services.Models;

namespace UsersAPI.Services.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate? _requestDelegate;

        public ExceptionMiddleware(RequestDelegate? requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (ApplicationException e)
            {
                await HandleExceptionAsync(context, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            switch (exception)
            {
                case ApplicationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case Exception:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";

            var errorResultModel = new ErrorResultModel
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
            };

            await context.Response.WriteAsync(errorResultModel.ToString());
        }
    }
}