using MediatR;

namespace DebitCardService.ApplicationServices.API.Domain;

public class UpdateDebitCardActivityRequest : IRequest<UpdateDebitCardActivityResponse>
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}
