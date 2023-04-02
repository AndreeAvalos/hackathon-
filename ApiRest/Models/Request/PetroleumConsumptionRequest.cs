namespace ApiRest.Models;

public class PetroleumConsumptionRequest
{
    public double Units { get; set; }
    public DateTime ConsumptionDate { get; set; }
    public int PetroleumCatalogId { get; set; }
    public int IssuanceCatalogId { get; set; }
    public int DerivativeCatalogId { get; set; }
}