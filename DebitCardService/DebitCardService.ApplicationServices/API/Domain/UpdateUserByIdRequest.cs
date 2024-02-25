using MediatR;
using static DebitCardService.DataAccess.Entities.User;

namespace DebitCardService.ApplicationServices.API.Domain;

public class UpdateUserByIdRequest : IRequest<UpdateUserByIdResponse>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public Role AccessLevel { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; }
}
