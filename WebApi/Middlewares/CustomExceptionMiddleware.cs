using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApi.Middlewares
{
    public class CustomMiddlewareException
    {
        private readonly RequestDelegate _next;
        public CustomMiddlewareException(RequestDelegate next)
        {
            _next=next;
        }

         public async Task Invoke(HttpContext context)
        {   
            // var watch=Stopwatch.StartNew();
            // string message="[Request] HTTP "+ context.Request.Method+" - "+context.Request.Path;
            // Console.WriteLine(message);
            // await _next(context);
            // watch.Stop();
            // message="[Response] HTTP"+ context.Request.Method+" - "+context.Request.Path+" responded "+context.Response.StatusCode+" in "+watch.Elapsed.TotalMilliseconds+" ms";
            // Console.WriteLine(message);

             var watch=Stopwatch.StartNew(); 
            try
            {
                string message="[Request] HTTP "+ context.Request.Method+" - "+context.Request.Path;
                Console.WriteLine(message);
                await _next(context);                
                message="[Response] HTTP"+ context.Request.Method+" - "+context.Request.Path+" responded "+context.Response.StatusCode+" in "+watch.Elapsed.TotalMilliseconds+" ms";
                Console.WriteLine(message);

            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandeException(context, ex, watch);
                
            }

         }

        private Task HandeException(HttpContext context, Exception ex, Stopwatch watch)
        {
            //Burada yapılan işlem middleware metodu ile hata fırlatan bir requesti yakalayıp CRUD işlemleri içerisinde try-catch kirliliğini engellemek.
           context.Response.ContentType="application/json";
           context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
           string message="[Error] HTTP "+ context.Request.Method+" - "+context.Response.StatusCode+" Error message "+ex.Message+" in " +watch.Elapsed.TotalMilliseconds+" ms";
           Console.WriteLine(message);                           
           var result=JsonConvert.SerializeObject(new {error=ex.Message}, Formatting.None);
           return context.Response.WriteAsync(result);     
        }
    }
   
    public static class CustomMiddlewareExceptionExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddlewareException>();
        }
    }
}