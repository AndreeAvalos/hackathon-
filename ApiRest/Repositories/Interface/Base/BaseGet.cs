namespace ApiRest.Repositories.Interface.Base;

public interface IRepositoryGet<TImpl, TResponse> where TImpl : class
{
    public Task<TResponse> GetAsync();
}

public interface IRepositoryGetBy<TImpl, TResponse> where TImpl : class
{
    public Task<TResponse> GetByAsync<TPrimitiveType>(TPrimitiveType filterData);
}
public interface IRepositoryGetAll<TImpl, TResponse> where TImpl : class
{
    public Task<List<TResponse>> GetAllAsync();
}