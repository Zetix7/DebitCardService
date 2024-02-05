using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
{
    public int UserId { get; set; }
}
