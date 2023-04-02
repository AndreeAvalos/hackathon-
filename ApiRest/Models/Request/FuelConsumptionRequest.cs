namespace ApiRest.Models;

public class FuelConsumptionRequest
{
    public double Units { get; set; }
    public DateTime ConsumptionDate { get; set; }
    public int FuelCatalogId { get; set; }
    public int IssuanceCatalogId { get; set; }
}