using ApiRest.Responses;

namespace ApiRest.Services.Interface.Base;

public interface IServiceGet<TImpl, TResponse> where TImpl : class
{
    public Task<RSuccess<TResponse>> GetAsync();
}
