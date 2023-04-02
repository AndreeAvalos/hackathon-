using ApiRest.Enums;

namespace ApiRest.Responses;

public class RError
{
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; }

    public RError(StatusCodeEnum statusCodeEnum, List<string> errors)
    {
        StatusCode = (int)statusCodeEnum;
        Errors = errors;
    }

    public RError(StatusCodeEnum statusCodeEnum, string message)
    {
        StatusCode = (int)statusCodeEnum;
        Errors = new() { message };
    }
}