using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Entities.Base;
using ApiRest.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities;

[Table("fuel_consumption")]
public class FuelConsumptionEntity : BaseEntity
{
    [Column("units")]
    [Comment("Number of unit per use")]
    public double Units { get; set; }

    [Column("consumption_date")] public DateTime ConsumptionDate { get; set; }

    [Column("fuel_catalog_id"), ForeignKey("fuel_catalog_id")]
    public int FuelCatalogId { get; set; }

    [Column("issuance_catalog_id"), ForeignKey("issuance_catalog_id")]
    public int IssuanceCatalogId { get; set; }

    public virtual IssuanceCatalogEntity IssuanceCatalog { get; set; } = null!;
    public virtual FuelCatalogEntity FuelCatalog { get; set; } = null!;
}