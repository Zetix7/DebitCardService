using System.ComponentModel.DataAnnotations;

namespace DebitCardService.DataAccess.Entities;

public class User : EntityBase
{
    public List<DebitCard>? DebitCards { get; set; }

    [StringLength(20, MinimumLength = 1)]
    public string? FirstName { get; set; }

    [StringLength(30, MinimumLength = 1)]
    public string? LastName { get; set; }
}
