using MediatR;
using System.ComponentModel;

namespace DebitCardService.ApplicationServices.API.Domain;

public class UpdateDebitCardRequest : IRequest<UpdateDebitCardResponse>
{
    public int Id { get; set; }
    public int PinCode { get; set; }
    public bool IsActive { get; set; }
    public bool IsActiveCashWithdrawal { get; set; }
    public int CashWithdrawalLimit { get; set; }
    public bool IsActiveByPayPass { get; set; }
    public int PayPassLimit { get; set; }
    public bool IsActiveByPhone { get; set; }
    public int PhoneLimit { get; set; }
}
