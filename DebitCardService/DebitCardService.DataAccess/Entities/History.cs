using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DebitCardService.DataAccess.Entities;

public class History : EntityBase
{
    public int DebitCardId { get; set; }
    public DebitCard? DebitCard { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfOperation { get; set; } = DateTime.Now;

    [Required]
    [StringLength(51, MinimumLength = 3)]
    public string? Sender { get; set; }

    [Required]
    [StringLength(26, MinimumLength = 26)]
    public string? SenderAccountNumber { get; set; }

    [Required]
    [StringLength(51, MinimumLength = 3)]
    public string? Recipient { get; set; }

    [Required]
    [StringLength(26, MinimumLength = 26)]
    public string? RecipientAccountNumber { get; set; }

    [Required]
    [Precision(17, 2)]
    public decimal Amount { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string? Title { get; set; }
}