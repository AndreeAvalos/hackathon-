using ApiRest.Entities;
using ApiRest.Enums;
using ApiRest.Models;
using ApiRest.Repositories.Implementation;
using ApiRest.Repositories.Interface.Base;
using ApiRest.Responses;
using ApiRest.Services.Interface.Base;

namespace ApiRest.Services.Implementation;

public class TravelServiceImpl : IServiceSave<TravelServiceImpl, TravelRequest, bool>
{
    private readonly IRepositorieSave<TravelRepositoryImpl, TravelEntity> _repositorySave;

    public TravelServiceImpl(IServiceProvider provider)
    {
        _repositorySave =
            provider.GetRequiredService<IRepositorieSave<TravelRepositoryImpl, TravelEntity>>();
    }

    public async Task<RSuccess<bool>> SaveAsync(TravelRequest request)
    {
        TravelEntity TravelEntity = new()
        {
            Destination = request.Destination,
            TravelDate = request.TravelDate,
            TravelCatalogId = request.TravelCatalogId,
            IssuanceCatalogId = request.IssuanceCatalogId
        };
        await _repositorySave.SaveAsync(TravelEntity);
        return new(StatusCodeEnum.Created, true);
    }
}