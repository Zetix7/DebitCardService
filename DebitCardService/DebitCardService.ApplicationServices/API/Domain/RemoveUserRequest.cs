using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class RemoveUserRequest : RequestBase, IRequest<RemoveUserResponse>
{
    public int Id { get; set; }
}
