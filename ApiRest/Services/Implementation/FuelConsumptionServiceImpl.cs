using ApiRest.Entities;
using ApiRest.Enums;
using ApiRest.Models;
using ApiRest.Models.Response;
using ApiRest.Repositories.Implementation;
using ApiRest.Repositories.Interface.Base;
using ApiRest.Responses;
using ApiRest.Services.Interface.Base;

namespace ApiRest.Services.Implementation;

public class FuelConsumptionServiceImpl : IServiceSave<FuelConsumptionServiceImpl, FuelConsumptionRequest, bool>,
    IServiceGet<FuelConsumptionServiceImpl, FuelPercentageResponse>,
    IServiceGet<FuelConsumptionServiceImpl, FuelAverageResponse>
{
    private readonly IRepositorieSave<FuelConsumptionRepositoryImpl, FuelConsumptionEntity> _repositorySave;
    private readonly IRepositoryGetAll<FuelConsumptionRepositoryImpl, FuelConsumptionEntity> _repositoryGetAll;

    public FuelConsumptionServiceImpl(IServiceProvider provider)
    {
        _repositorySave =
            provider.GetRequiredService<IRepositorieSave<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>>();
        _repositoryGetAll =
            provider.GetRequiredService<IRepositoryGetAll<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>>();
    }

    public async Task<RSuccess<bool>> SaveAsync(FuelConsumptionRequest request)
    {
        FuelConsumptionEntity fuelConsumptionEntity = new()
        {
            Units = request.Units,
            ConsumptionDate = request.ConsumptionDate,
            FuelCatalogId = request.FuelCatalogId,
            IssuanceCatalogId = request.IssuanceCatalogId
        };
        await _repositorySave.SaveAsync(fuelConsumptionEntity);
        return new(StatusCodeEnum.Created, true);
    }

    public async Task<RSuccess<FuelPercentageResponse>> GetAsync()
    {
        List<FuelConsumptionEntity> fuelConsumptionEntities = await _repositoryGetAll.GetAllAsync();
        double total = fuelConsumptionEntities.Sum(fuelConsumptionEntity => fuelConsumptionEntity.Units);
        List<FuelConsumptionEntity> administrative = fuelConsumptionEntities
            .Where(fuelConsumptionEntity => fuelConsumptionEntity.FuelCatalogId == -1).ToList();
        List<FuelConsumptionEntity> indirect = fuelConsumptionEntities
            .Where(fuelConsumptionEntity => fuelConsumptionEntity.FuelCatalogId == -2).ToList();
        List<FuelConsumptionEntity> logistic = fuelConsumptionEntities
            .Where(fuelConsumptionEntity => fuelConsumptionEntity.FuelCatalogId == -3).ToList();

        double administrativeTotal = administrative.Sum(entity => entity.Units);
        double indirectTotal = indirect.Sum(entity => entity.Units);
        double logisticTotal = logistic.Sum(entity => entity.Units);

        FuelPercentageResponse fuelPercentageResponse = new()
        {
            Body = new()
            {
                new()
                {
                    Category = "Combustible administrativo",
                    Percentage = Convert.ToInt32(administrativeTotal / total * 100)
                },
                new()
                {
                    Category = "Combustible indirecto de proveedor",
                    Percentage = Convert.ToInt32(indirectTotal / total * 100)
                },
                new()
                {
                    Category = "Combustible de logistico",
                    Percentage = Convert.ToInt32(logisticTotal / total * 100)
                }
            }
        };
        return new(StatusCodeEnum.Ok, fuelPercentageResponse);
    }

    async Task<RSuccess<FuelAverageResponse>> IServiceGet<FuelConsumptionServiceImpl, FuelAverageResponse>.GetAsync()
    {
        List<FuelConsumptionEntity> fuelConsumptionEntities = await _repositoryGetAll.GetAllAsync();
        double average = fuelConsumptionEntities.Average(entity => entity.Units);
        return new(StatusCodeEnum.Ok, new()
        {
            Type = "Galon",
            Units = average/12
        });
    }
}