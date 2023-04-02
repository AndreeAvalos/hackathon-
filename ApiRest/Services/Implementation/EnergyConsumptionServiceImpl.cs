using ApiRest.Entities;
using ApiRest.Enums;
using ApiRest.Models;
using ApiRest.Models.Response;
using ApiRest.Repositories.Implementation;
using ApiRest.Repositories.Interface.Base;
using ApiRest.Responses;
using ApiRest.Services.Interface.Base;

namespace ApiRest.Services.Implementation;

public class EnergyConsumptionServiceImpl : IServiceSave<EnergyConsumptionServiceImpl, EnergyConsumptionRequest, bool>,
    IServiceGet<EnergyConsumptionServiceImpl, FuelPercentageBody>
{
    private readonly IRepositorieSave<EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity> _repositorySave;
    private readonly IRepositoryGetAll<EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity> _repositoryGetAll;

    public EnergyConsumptionServiceImpl(IServiceProvider provider)
    {
        _repositorySave =
            provider.GetRequiredService<IRepositorieSave<EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity>>();
        _repositoryGetAll =
            provider.GetRequiredService<IRepositoryGetAll<
                EnergyConsumptionRepositoryImpl, EnergyConsumptionEntity>>();
    }

    public async Task<RSuccess<bool>> SaveAsync(EnergyConsumptionRequest request)
    {
        EnergyConsumptionEntity energyConsumptionEntity = new()
        {
            Units = request.Units,
            ConsumptionDate = request.ConsumptionDate,
            EnergyCatalogId = request.EnergyCatalogId,
            IssuanceCatalogId = request.IssuanceCatalogId,
            EnergyTypeCatalogId = request.EnergyTypeCatalogId
        };
        await _repositorySave.SaveAsync(energyConsumptionEntity);
        return new(StatusCodeEnum.Created, true);
    }

    public async Task<RSuccess<FuelPercentageBody>> GetAsync()
    {
        List<EnergyConsumptionEntity> energyConsumptionEntities = await _repositoryGetAll.GetAllAsync();
        double average = energyConsumptionEntities.Where(x => x.EnergyTypeCatalogId == -2)
            .Average(entity => entity.Units);
        return new(StatusCodeEnum.Ok, new()
        {
            Category = "Envasado",
            Percentage = Convert.ToInt32(average / 12)
        });
    }
}