using System.ComponentModel.DataAnnotations;

namespace DebitCardService.DataAccess.Entities;

public class DebitCard : EntityBase
{
    public string? AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string? CardNumber { get; set; }
    public DateTime ExpirityDate { get; set; }
    public int Cvv2Code { get; set; }
    public int PinCode { get; set; }
    public string? CardHolder { get; set; }
    public bool IsActive { get; set; }
    public bool IsActiveCashWithdrawal { get; set; }
    public int CashWithdrawalLimit { get; set; }
    public bool IsActiveByPayPass { get; set; }
    public int PayPassLimit { get; set; }
    public bool IsActiveByPhone { get; set; }
    public int PhoneLimit { get; set; }
}
