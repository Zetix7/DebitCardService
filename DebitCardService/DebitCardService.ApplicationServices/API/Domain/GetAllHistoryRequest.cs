using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetAllHistoryRequest : IRequest<GetAllHistoryResponse>
{
    public decimal Amount { get; set; }
}
