using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Entities.Base;

namespace ApiRest.Entities.Catalogs;

[Table("fuel_catalog")]
public class FuelCatalogEntity : BaseEntity
{
    [Column("name")] public string Name { get; set; } = null!;
    [Column("description")] public string Description { get; set; } = null!;
}