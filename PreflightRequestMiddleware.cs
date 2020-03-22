using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication
{
  public class PreflightRequestMiddleware
  {
    private readonly RequestDelegate Next;
    public PreflightRequestMiddleware(RequestDelegate next)
    {
      Next = next;
    }
    public Task Invoke(HttpContext context)
    {
      return BeginInvoke(context);
    }
    private Task BeginInvoke(HttpContext context)
    {
      if (context.Request.Method == "OPTIONS")
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("OK");
            }

            return Next.Invoke(context);
    }
  }

  public static class PreflightRequestExtensions
  {
    public static IApplicationBuilder UsePreflightRequestHandler(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<PreflightRequestMiddleware>();
    }
  }
}