using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class RemoveUserRequest : IRequest<RemoveUserResponse>
{
    public int Id { get; set; }
}
