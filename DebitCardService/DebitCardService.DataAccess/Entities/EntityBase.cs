using System.ComponentModel.DataAnnotations;

namespace DebitCardService.DataAccess.Entities;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}
