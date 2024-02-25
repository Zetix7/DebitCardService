using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetUsersRequest : RequestBase, IRequest<GetUsersResponse>
{
    public string? Login { get; set; }
}
