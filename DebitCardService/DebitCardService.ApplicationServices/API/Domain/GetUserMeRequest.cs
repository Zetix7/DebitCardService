using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class GetUserMeRequest : RequestBase, IRequest<GetUserMeResponse>
{
    public string? Me { get; set; }
}
