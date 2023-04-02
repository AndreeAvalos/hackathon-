namespace ApiRest.Models;

public class TravelRequest
{
    public string Destination { get; set; }
    public DateTime TravelDate { get; set; }
    public int TravelCatalogId { get; set; }
    public int IssuanceCatalogId { get; set; }
}