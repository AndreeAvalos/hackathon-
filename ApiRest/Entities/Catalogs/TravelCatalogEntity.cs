using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Entities.Catalogs;
[Table("travel_catalog")]
[Comment("Kind of travel")]
public class TravelCatalogEntity: BaseEntity
{
    [Column("name")] public string Name { get; set; } = null!;
    [Column("description")] public string Description { get; set; } = null!;
}