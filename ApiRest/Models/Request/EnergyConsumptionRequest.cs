namespace ApiRest.Models;

public class EnergyConsumptionRequest
{
    public double Units { get; set; }
    public DateTime ConsumptionDate { get; set; }
    public int EnergyCatalogId { get; set; }
    public int IssuanceCatalogId { get; set; }
    public int EnergyTypeCatalogId { get; set; }
}