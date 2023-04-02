using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Entities.Base;
using ApiRest.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities;

[Table("energy_consumption")]
public class EnergyConsumptionEntity : BaseEntity
{
    [Column("units")]
    [Comment("Number of unit per use")]
    public double Units { get; set; }

    [Column("consumption_date")] public DateTime ConsumptionDate { get; set; }

    [Column("energy_catalog_id"), ForeignKey("energy_catalog_id")]
    public int EnergyCatalogId { get; set; }

    [Column("issuance_catalog_id"), ForeignKey("issuance_catalog_id")]
    public int IssuanceCatalogId { get; set; }

    [Column("energy_type_catalog_id"), ForeignKey("energy_type_catalog_id")]
    public int EnergyTypeCatalogId { get; set; }

    public virtual IssuanceCatalogEntity IssuanceCatalog { get; set; } = null!;
    public virtual EnergyTypeCatalogEntity EnergyTypeCatalog { get; set; } = null!;
    public virtual EnergyCatalogEntity EnergyCatalog { get; set; } = null!;
}