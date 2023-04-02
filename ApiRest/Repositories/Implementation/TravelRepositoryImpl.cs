using ApiRest.Database.Context;
using ApiRest.Entities;
using ApiRest.Repositories.Interface.Base;

namespace ApiRest.Repositories.Implementation;

public class TravelRepositoryImpl : IRepositorieSave<TravelRepositoryImpl, TravelEntity>
{
    private readonly CustomContext _context;

    public TravelRepositoryImpl(CustomContext context)
    {
        _context = context;
    }

    public async Task<TravelEntity> SaveAsync(TravelEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}