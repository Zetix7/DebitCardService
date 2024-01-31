using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IRepository<DataAccess.Entities.User> _userRepository;

    public GetUsersHandler(IRepository<DataAccess.Entities.User> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAll();
        var domainUsers = users.Select(x => new User
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName
        }).ToList();

        var response = new GetUsersResponse()
        {
            Data = domainUsers
        };

        return Task.FromResult(response);
    }
}
