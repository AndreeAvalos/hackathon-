namespace ApiRest.Repositories.Interface.Base;

public interface IRepositorieSave<TImpl, TRequest> where TImpl : class
{
    public Task<TRequest> SaveAsync(TRequest entity);
}