using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
namespace dotNetCore

{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<div> Hello from Simple Middleware </div>");
            await context.Response.WriteAsync("<div>  </div>");
            await context.Response.WriteAsync("<table>");
            await context.Response.WriteAsync("<style>table, th, td { border: 1px solid black;}</style>");
            await context.Response.WriteAsync($"<tr><th > Data from http request </th></tr>");
            await context.Response.WriteAsync($"<tr><td >Scheme:{context.Request.Scheme}</td></tr>");
            await context.Response.WriteAsync($"<tr><td >Host:{context.Request.Host}</td></tr>");
            await context.Response.WriteAsync($"<tr><td >Path:{context.Request.Path}</td></tr>");
            await context.Response.WriteAsync($"<tr><td>QueryString:{context.Request.QueryString}</td></tr>");
            await context.Response.WriteAsync($"<tr><td>Request Body:{context.Request.Body}</td></tr>");
            await context.Response.WriteAsync($"</table>");

            string[] lines =
            {
                $"Scheme:{context.Request.Scheme}" ,
                $"Host:{context.Request.Host}" ,
                $"Path:{context.Request.Path}" ,
                $"QueryString:{context.Request.QueryString}",
                $"Request Body:{context.Request.Body}"
            };

            await File.WriteAllLinesAsync("WriteLines.txt", lines);
            await _next(context);
        }
    }
}