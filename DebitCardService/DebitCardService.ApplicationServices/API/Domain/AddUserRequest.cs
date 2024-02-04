using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class AddUserRequest : IRequest<AddUserResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
}
