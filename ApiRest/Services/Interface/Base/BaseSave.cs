using ApiRest.Responses;

namespace ApiRest.Services.Interface.Base;

public interface IServiceSave<TImpl, TRequest> where TImpl : class
{
    public Task<RSuccess<TRequest>> SaveAsync(TRequest request);
}
public interface IServiceSave<TImpl, TRequest, TResponse> where TImpl : class
{
    public Task<RSuccess<TResponse>> SaveAsync(TRequest request);
}