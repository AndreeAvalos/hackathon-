using ApiRest.Database.Context;
using ApiRest.Entities;
using ApiRest.Repositories.Interface.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Repositories.Implementation;

public class FuelConsumptionRepositoryImpl : IRepositorieSave<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>,
    IRepositoryGetAll<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>
{
    private readonly CustomContext _context;

    public FuelConsumptionRepositoryImpl(CustomContext context)
    {
        _context = context;
    }

    public async Task<FuelConsumptionEntity> SaveAsync(FuelConsumptionEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }


    public async Task<List<FuelConsumptionEntity>> GetAllAsync()
    {
        return await _context.FuelConsumptionEntities.Include(x => x.FuelCatalog).ToListAsync();
    }
}