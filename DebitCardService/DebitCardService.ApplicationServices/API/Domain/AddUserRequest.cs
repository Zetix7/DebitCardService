using static DebitCardService.DataAccess.Entities.User;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class AddUserRequest : RequestBase, IRequest<AddUserResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role AccessLevel { get; set; }
    public string? Login { get; set; }
    public string? HashedPassword { get; set; }
    public bool IsActive { get; set; }
}
