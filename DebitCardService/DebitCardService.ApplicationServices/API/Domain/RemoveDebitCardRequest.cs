using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class RemoveDebitCardRequest : RequestBase, IRequest<RemoveDebitCardResponse>
{
    public int Id { get; set; }
}
