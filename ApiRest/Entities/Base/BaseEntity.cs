using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Entities.Base;

public class BaseEntity: BaseEntityTimestamp
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(name: "id")]
    public int Id { get; set; }
}