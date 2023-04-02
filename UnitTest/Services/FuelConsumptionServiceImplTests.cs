using ApiRest.Entities;
using ApiRest.Enums;
using ApiRest.Models;
using ApiRest.Models.Response;
using ApiRest.Repositories.Implementation;
using ApiRest.Repositories.Interface.Base;
using ApiRest.Responses;
using ApiRest.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTest.Controllers;

public class FuelConsumptionServiceImplTests
{
    private readonly Mock<IRepositorieSave<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>> _repositorySave;
    private readonly Mock<IRepositoryGetAll<FuelConsumptionRepositoryImpl, FuelConsumptionEntity>> _repositoryGetAll;
    private readonly FuelConsumptionServiceImpl _service;

    public FuelConsumptionServiceImplTests()
    {
        _repositorySave = new();
        _repositoryGetAll = new();

        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton(_repositorySave.Object);
        serviceCollection.AddSingleton(_repositoryGetAll.Object);

        _service = new(serviceCollection.BuildServiceProvider());
    }


    [Fact(DisplayName = "FuelConsumptionServiceImpl SaveAsync FuelConsumptionRequest return true")]
    public async Task FuelConsumptionServiceImpl_SaveAsync_FuelConsumptionRequest_Bool()
    {
        FuelConsumptionRequest fuelConsumptionRequest = new()
        {
            Units = 100,
            ConsumptionDate = DateTime.UtcNow,
            FuelCatalogId = -1,
            IssuanceCatalogId = -1
        };

        RSuccess<bool> expected = new(StatusCodeEnum.Created, true);
        _repositorySave.Setup(context => context.SaveAsync(It.IsAny<FuelConsumptionEntity>()));

        RSuccess<bool> result = await _service.SaveAsync(fuelConsumptionRequest);

        Assert.Equal(expected.StatusCode, result.StatusCode);
        Assert.Equal(expected.Data, result.Data);
    }

    [Fact(DisplayName = "FuelConsumptionServiceImpl GetAsync FuelConsumptionRequest return FuelPercentageResponse")]
    public async Task FuelConsumptionServiceImpl_SaveAsync_FuelConsumptionRequest_FuelPercentageResponse()
    {
        List<FuelConsumptionEntity> fuelConsumptionEntities = new()
        {
            new()
            {
                Units = 33,
                FuelCatalogId = -1
            },
            new()
            {
                Units = 33,
                FuelCatalogId = -2
            },
            new()
            {
                Units = 34,
                FuelCatalogId = -3
            }
        };

        FuelPercentageResponse fuelPercentageResponse = new()
        {
            Body = new()
            {
                new()
                {
                    Category = "Combustible administrativo",
                    Percentage = 33
                },
                new()
                {
                    Category = "Combustible indirecto de proveedor",
                    Percentage = 33
                },
                new()
                {
                    Category = "Combustible de logistico",
                    Percentage = 34
                }
            }
        };

        RSuccess<FuelPercentageResponse> expected = new(StatusCodeEnum.Ok, fuelPercentageResponse);

        _repositoryGetAll.Setup(context => context.GetAllAsync())
            .ReturnsAsync(fuelConsumptionEntities);

        RSuccess<FuelPercentageResponse> result = await _service.GetAsync();

        Assert.Equal(expected.StatusCode, result.StatusCode);
        Assert.Equivalent(expected.Data, result.Data);
    }
}