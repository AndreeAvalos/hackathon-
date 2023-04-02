using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Entities.Base;
using ApiRest.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities;

[Table("petroleum_consumption")]
public class PetroleumConsumptionEntity : BaseEntity
{
    [Column("units")]
    [Comment("Number of unit per use")]
    public double Units { get; set; }

    [Column("consumption_date")] public DateTime ConsumptionDate { get; set; }

    [Column("petroleum_catalog_id"), ForeignKey("petroleum_catalog_id")]
    public int PetroleumCatalogId { get; set; }

    [Column("issuance_catalog_id"), ForeignKey("issuance_catalog_id")]
    public int IssuanceCatalogId { get; set; }

    [Column("derivative_catalog_id"), ForeignKey("derivative_catalog_id")]
    public int DerivativeCatalogId { get; set; }

    public virtual IssuanceCatalogEntity IssuanceCatalog { get; set; } = null!;
    public virtual PetroleumCatalogEntity PetroleumCatalog { get; set; } = null!;
    public virtual DerivativeCatalogEntity DerivativeCatalog { get; set; } = null!;
}