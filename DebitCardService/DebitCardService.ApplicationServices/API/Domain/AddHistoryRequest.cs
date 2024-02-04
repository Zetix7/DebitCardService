using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class AddHistoryRequest : IRequest<AddHistoryResponse>
{
    public int DebitCardId { get; set; }
    public DateTime DateOfOperation { get; set; } = DateTime.Now;
    public string? Sender { get; set; }
    public string? SenderAccountNumber { get; set; }
    public string? Recipient { get; set; }
    public string? RecipientAccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string? Title { get; set; }

}
