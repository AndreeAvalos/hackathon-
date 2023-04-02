using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Entities.Base;
using ApiRest.Entities.Catalogs;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities;

[Table("travel")]
[Comment("Number of travels")]
public class TravelEntity : BaseEntity
{
    [Column("destination")] public string Destination { get; set; } = null!;
    [Column("travel_date")] public DateTime TravelDate { get; set; }

    [Column("issuance_catalog_id"), ForeignKey("issuance_catalog_id")]
    public int IssuanceCatalogId { get; set; }

    [Column("travel_catalog_id"), ForeignKey("travel_catalog_id")]
    public int TravelCatalogId { get; set; }

    public virtual TravelCatalogEntity TravelCatalog { get; set; } = null!;
    public virtual IssuanceCatalogEntity IssuanceCatalog { get; set; } = null!;
}