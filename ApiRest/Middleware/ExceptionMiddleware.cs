using System.Text.Json;
using ApiRest.Enums;
using ApiRest.Responses;

namespace ApiRest.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomException customException)
        {
            await BuildResponseAsync(context, customException.GetResponse(), customException);
        }
        catch (Exception exception)
        {
            await BuildResponseAsync(context, new RError(StatusCodeEnum.InternalServerError, "Internal Server Error"),
                exception);
        }
    }

    private async Task BuildResponseAsync(HttpContext context, RError getResponse, Exception customException)
    {
        context.Response.StatusCode = getResponse.StatusCode;
        context.Response.ContentType = "application/json";
        var logInput = new
        {
            path = context.Request.Path,
            method = context.Request.Method,
            message = customException.Message,
            trace = customException.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
        };
        string log = JsonSerializer.Serialize(logInput);
        Console.WriteLine(log);
        await context.Response.WriteAsync(JsonSerializer.Serialize(getResponse));
    }
}