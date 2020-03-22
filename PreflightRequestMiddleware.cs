using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

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
      context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
      context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept, Athorization, ActualUserOrImpersonatedUserSamAccount, IsImpersonatedUser" });
      context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
      if (context.Request.Method == HttpMethod.Options.Method)
      {
        context.Response.StatusCode = (int)HttpStatusCode.OK;
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