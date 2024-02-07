using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class RemoveDebitCardRequest : IRequest<RemoveDebitCardResponse>
{
    public int Id { get; set; }
}
