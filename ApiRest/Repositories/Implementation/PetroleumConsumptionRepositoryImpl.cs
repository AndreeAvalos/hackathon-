using ApiRest.Database.Context;
using ApiRest.Entities;
using ApiRest.Repositories.Interface.Base;

namespace ApiRest.Repositories.Implementation;

public class
    PetroleumConsumptionRepositoryImpl : IRepositorieSave<PetroleumConsumptionRepositoryImpl, PetroleumConsumptionEntity>
{
    private readonly CustomContext _context;

    public PetroleumConsumptionRepositoryImpl(CustomContext context)
    {
        _context = context;
    }

    public async Task<PetroleumConsumptionEntity> SaveAsync(PetroleumConsumptionEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}