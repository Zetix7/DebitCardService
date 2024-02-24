using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class UpdateUserNameByIdRequest : IRequest<UpdateUserNameByIdResponse>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
}
