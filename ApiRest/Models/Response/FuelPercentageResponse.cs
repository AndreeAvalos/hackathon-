namespace ApiRest.Models.Response;

public class FuelPercentageResponse
{
    public List<FuelPercentageBody> Body { get; set; } = null!;
}

public class FuelPercentageBody
{
    public string Category { get; set; } = null!;
    public int Percentage { get; set; }
}