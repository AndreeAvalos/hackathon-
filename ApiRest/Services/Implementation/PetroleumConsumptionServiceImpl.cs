using ApiRest.Entities;
using ApiRest.Enums;
using ApiRest.Models;
using ApiRest.Repositories.Implementation;
using ApiRest.Repositories.Interface.Base;
using ApiRest.Responses;
using ApiRest.Services.Interface.Base;

namespace ApiRest.Services.Implementation;

public class PetroleumConsumptionServiceImpl : IServiceSave<PetroleumConsumptionServiceImpl, PetroleumConsumptionRequest, bool>
{
    private readonly IRepositorieSave<PetroleumConsumptionRepositoryImpl, PetroleumConsumptionEntity> _repositorySave;

    public PetroleumConsumptionServiceImpl(IServiceProvider provider)
    {
        _repositorySave =
            provider.GetRequiredService<IRepositorieSave<PetroleumConsumptionRepositoryImpl, PetroleumConsumptionEntity>>();
    }

    public async Task<RSuccess<bool>> SaveAsync(PetroleumConsumptionRequest request)
    {
        PetroleumConsumptionEntity PetroleumConsumptionEntity = new()
        {
            Units = request.Units,
            ConsumptionDate = request.ConsumptionDate,
            PetroleumCatalogId = request.PetroleumCatalogId,
            IssuanceCatalogId = request.IssuanceCatalogId,
            DerivativeCatalogId = request.DerivativeCatalogId
        };
        await _repositorySave.SaveAsync(PetroleumConsumptionEntity);
        return new(StatusCodeEnum.Created, true);
    }
}