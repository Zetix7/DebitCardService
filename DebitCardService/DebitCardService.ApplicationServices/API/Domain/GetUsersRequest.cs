using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetUsersRequest : IRequest<GetUsersResponse>
{
    public string? LastName { get; set; }
}
