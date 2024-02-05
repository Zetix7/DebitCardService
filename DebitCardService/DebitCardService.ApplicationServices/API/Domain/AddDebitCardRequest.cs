using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class AddDebitCardRequest : IRequest<AddDebitCardResponse>
{
    public string? AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string? CardNumber { get; set; }
    public DateTime ExpirityDate { get; set; }
    public int Cvv2Code { get; set; }
    public int PinCode { get; set; }
    public string? CardHolder { get; set; }
    public bool IsActive { get; set; }
    public int UserId { get; set; }
}
