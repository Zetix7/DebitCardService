using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetDebitCardByIdRequest : RequestBase, IRequest<GetDebitCardByIdResponse>
{
    public int Id { get; set; }
}
