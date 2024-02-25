using System.ComponentModel.DataAnnotations;

namespace DebitCardService.DataAccess.Entities;

public class User : EntityBase
{
    public enum Role
    {
        AdminService = 0,
        UserService = 1
    }

    public List<DebitCard>? DebitCards { get; set; }

    [StringLength(20, MinimumLength = 1)]
    public string? FirstName { get; set; }

    [StringLength(30, MinimumLength = 1)]
    public string? LastName { get; set; }

    [Required]
    public Role AccessLevel { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 8)]
    public string? Login { get; set; }
    
    [Required]
    public string? Password { get; set; }

    [Required]
    public bool IsActive { get; set; }
}
