using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DebitCardService.DataAccess.Entities;

public class DebitCard : EntityBase
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public List<History>? History { get; set; }

    [Required]
    [StringLength(26, MinimumLength = 26)]
    public string? AccountNumber { get; set; }
    
    [Required]
    [DefaultValue(0)]
    [Precision(17, 2)]
    public decimal Amount { get; set; }

    [Required]
    [StringLength(16, MinimumLength = 16)]
    public string? CardNumber { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ExpirityDate { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 3)]
    public int Cvv2Code { get; set; }

    [Required]
    [StringLength(4, MinimumLength = 4)]
    public int PinCode { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? CardHolder { get; set; }

    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }
    
    [DefaultValue(false)]
    public bool IsActiveCashWithdrawal { get; set; }
    
    [DefaultValue(0)]
    public int CashWithdrawalLimit { get; set; }
    
    [DefaultValue(false)]
    public bool IsActiveByPayPass { get; set; }
    
    [DefaultValue(0)]
    public int PayPassLimit { get; set; }
    
    [DefaultValue(false)]
    public bool IsActiveByPhone { get; set; }
    
    [DefaultValue(0)]
    public int PhoneLimit { get; set; }
}
