using OnlineShopingApi.Exceptions;
using OnlineShopingApi.Models;
using System.Net;

namespace OnlineShopingApi.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            } catch(Exception ex)
            {
                var exceptiontype=ex.GetType();
                var Response = new APIResponse(null);
                Response.Status = "Failed";
                Response.ExceptionError = ex.Message;

                if (exceptiontype ==typeof (NotFoundException))
                {
                    Response.Code = (int)HttpStatusCode.NotFound;
                }
                else if (exceptiontype == typeof(UnauthorizedAccessException))
                    Response.Code = (int)HttpStatusCode.Unauthorized;

                var result = Response.ToString();
                context.Response.ContentType = "application/json";
               await context.Response.WriteAsync(result);
               

            }
        }
    }
}
