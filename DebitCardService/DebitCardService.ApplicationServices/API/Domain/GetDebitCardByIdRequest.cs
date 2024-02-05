using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetDebitCardByIdRequest : IRequest<GetDebitCardByIdResponse>
{
    public int Id { get; set; }
}
