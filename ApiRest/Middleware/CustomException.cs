using ApiRest.Enums;
using ApiRest.Responses;

namespace ApiRest.Middleware;

public class CustomException : Exception
{
    private readonly List<string> _errors;
    private readonly StatusCodeEnum _statusCode;

    public CustomException(List<string> errors, StatusCodeEnum statusCode)
    {
        _errors = errors;
        _statusCode = statusCode;
    }

    public RError GetResponse() => new(_statusCode, _errors);
}