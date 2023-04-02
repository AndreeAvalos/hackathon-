using ApiRest.Database.Context;
using ApiRest.Entities;
using ApiRest.Repositories.Interface.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Repositories.Implementation;

public class EnergyConsumptionRepositoryImpl :
    IRepositorieSave<EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity>,
    IRepositoryGetAll<EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity>
{
    private readonly CustomContext _context;

    public EnergyConsumptionRepositoryImpl(CustomContext context)
    {
        _context = context;
    }

    public async Task<EnergyConsumptionEntity> SaveAsync(EnergyConsumptionEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<EnergyConsumptionEntity>> GetAllAsync()
    {
        return await _context.EnergyConsumptionEntities.Include(x => x.EnergyCatalog).ToListAsync();
    }
}