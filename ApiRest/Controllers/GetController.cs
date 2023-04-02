using ApiRest.Models.Response;
using ApiRest.Responses;
using ApiRest.Services.Implementation;
using ApiRest.Services.Interface.Base;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

[ApiController]
[Route("api/report")]
public class GetController
{
    private readonly IServiceGet<FuelConsumptionServiceImpl, FuelPercentageResponse> _getPercentage;
    private readonly IServiceGet<FuelConsumptionServiceImpl, FuelAverageResponse> _getAverage;
    private readonly IServiceGet<EnergyConsumptionServiceImpl, FuelPercentageBody> _getFourth;
    public GetController(IServiceProvider provider)
    {
        _getPercentage = provider.GetRequiredService<IServiceGet<FuelConsumptionServiceImpl, FuelPercentageResponse>>();
        _getAverage = provider.GetRequiredService<IServiceGet<FuelConsumptionServiceImpl, FuelAverageResponse>>();
        _getFourth = provider.GetRequiredService<IServiceGet<EnergyConsumptionServiceImpl, FuelPercentageBody>>();
    }

    /// <summary>
    ///     Endpoint primer punto
    /// </summary>
    /// <remarks>
    /// ## Description
    /// Calcular el porcentaje de consumo anual de combustible por categoría (en porcentaje)
    /// </remarks>
    [HttpGet("one")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RSuccess<FuelPercentageResponse>), 200)]
    [ProducesResponseType(typeof(RError), 400)]
    [ProducesResponseType(typeof(RError), 404)]
    [ProducesResponseType(typeof(RError), 500)]
    public async Task<IActionResult> GetOne()
    {
        return (await _getPercentage.GetAsync()).GetResponse();
    }
    
    /// <summary>
    ///     Endpoint segundo punto
    /// </summary>
    /// <remarks>
    /// ## Description
    /// Calcular el promedio mensual de consumo de combustible (en galones)
    /// </remarks>
    [HttpGet("two")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RSuccess<FuelAverageResponse>), 200)]
    [ProducesResponseType(typeof(RError), 400)]
    [ProducesResponseType(typeof(RError), 404)]
    [ProducesResponseType(typeof(RError), 500)]
    public async Task<IActionResult> GetTwo()
    {
        return (await _getAverage.GetAsync()).GetResponse();
    }
    
    /// <summary>
    ///     Endpoint cuarto punto
    /// </summary>
    /// <remarks>
    /// ## Description
    /// Calcular el promedio mensual de uso de energía eléctrica únicamente en la planta de envasado (en Kw)
    /// </remarks>
    [HttpGet("fourth")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RSuccess<FuelPercentageBody>), 200)]
    [ProducesResponseType(typeof(RError), 400)]
    [ProducesResponseType(typeof(RError), 404)]
    [ProducesResponseType(typeof(RError), 500)]
    public async Task<IActionResult> GetFourth()
    {
        return (await _getFourth.GetAsync()).GetResponse();
    }
}