using ApiRest.Models;
using ApiRest.Responses;
using ApiRest.Services.Implementation;
using ApiRest.Services.Interface.Base;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[ApiController]
[Route("api")]
public class PostController : ControllerBase
{
    private readonly IServiceSave<PetroleumConsumptionServiceImpl, PetroleumConsumptionRequest, bool>
        _petroleumService;

    private readonly IServiceSave<EnergyConsumptionServiceImpl, EnergyConsumptionRequest, bool> _energyService;
    private readonly IServiceSave<FuelConsumptionServiceImpl, FuelConsumptionRequest, bool> _fuelService;
    private readonly IServiceSave<TravelServiceImpl, TravelRequest, bool> _travelService;

    public PostController(IServiceProvider provider)
    {
        _petroleumService =
            provider
                .GetRequiredService<IServiceSave<PetroleumConsumptionServiceImpl, PetroleumConsumptionRequest, bool>>();

        _energyService = provider
            .GetRequiredService<IServiceSave<EnergyConsumptionServiceImpl, EnergyConsumptionRequest, bool>>();

        _fuelService =
            provider.GetRequiredService<IServiceSave<FuelConsumptionServiceImpl, FuelConsumptionRequest, bool>>();
        
        _travelService = provider.GetRequiredService<IServiceSave<TravelServiceImpl, TravelRequest, bool>>();
    }

    /// <summary>
    ///     Endpoint primer punto
    /// </summary>
    /// <remarks>
    /// ## Description
    /// Se necesita registrar el consumo de combustible categorizado por
    /// - combustible administrativo
    /// - combustible indirecto de proveedor - combustible de logística
    /// También se debe segmentar según tipo de emisión
    /// </remarks>
    [HttpPost("fuel")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RSuccess<bool>), 200)]
    [ProducesResponseType(typeof(RError), 400)]
    [ProducesResponseType(typeof(RError), 404)]
    [ProducesResponseType(typeof(RError), 500)]
    public async Task<IActionResult> PostFuelAsync(FuelConsumptionRequest request)
    {
        return (await _fuelService.SaveAsync(request)).GetResponse();
    }

    /// <summary>
    ///     Endpoint primer punto
    /// </summary>
    /// <remarks>
    /// ## Description
    /// Se necesita registrar el consumo de energía eléctrica categorizada por
    /// - consumo administrativo - consumo logístico
    /// - consumo de distribución
    /// También se debe segmentar según tipo de emisión
    /// </remarks>
    [HttpPost("energy")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RSuccess<bool>), 200)]
    [ProducesResponseType(typeof(RError), 400)]
    [ProducesResponseType(typeof(RError), 404)]
    [ProducesResponseType(typeof(RError), 500)]
    public async Task<IActionResult> PostEnergyAsync(EnergyConsumptionRequest request)
    {
        return (await _energyService.SaveAsync(request)).GetResponse();
    }

    /// <summary>
    ///     Endpoint primer punto
    /// </summary>
    /// <remarks>
    /// ## Description
    /// Se necesita registrar el consumo de otros productos derivados del petróleo categorizada por
    ///- consumo administrativo - consumo logístico
    ///- consumo de operación
    /// También se debe segmentar según tipo de emisión
    /// </remarks>
    [HttpPost("petroleum")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RSuccess<bool>), 200)]
    [ProducesResponseType(typeof(RError), 400)]
    [ProducesResponseType(typeof(RError), 404)]
    [ProducesResponseType(typeof(RError), 500)]
    public async Task<IActionResult> PostEnergyAsync(PetroleumConsumptionRequest request)
    {
        return (await _petroleumService.SaveAsync(request)).GetResponse();
    }

    /// <summary>
    ///     Endpoint primer punto
    /// </summary>
    /// <remarks>
    /// ## Description
    /// Registrar número de viajes. También se debe segmentar según tipo de emisión.
    /// </remarks>
    [HttpPost("travel")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RSuccess<bool>), 200)]
    [ProducesResponseType(typeof(RError), 400)]
    [ProducesResponseType(typeof(RError), 404)]
    [ProducesResponseType(typeof(RError), 500)]
    public async Task<IActionResult> PostTravelAsync(TravelRequest request)
    {
        return (await _travelService.SaveAsync(request)).GetResponse();
    }
}