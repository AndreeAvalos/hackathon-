using ApiRest.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Responses;

public class RSuccess<T>
{
    public int StatusCode { get; set; }
    public T Data { get; set; }

    public RSuccess(StatusCodeEnum statusCodeEnum, T data )
    {
        StatusCode = (int)statusCodeEnum;
        Data = data;
    }

    public ObjectResult GetResponse()
    {
        ObjectResult objectResult = new(this)
        {
            StatusCode = StatusCode
        };
        return objectResult;
    }
}