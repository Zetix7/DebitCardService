using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IRepository<DataAccess.Entities.User> _userRepository;
    private readonly IMapper _mapper;

    public GetUsersHandler(IRepository<DataAccess.Entities.User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAll();
        var mappedUsers = _mapper.Map<List<User>>(users);

        var response = new GetUsersResponse()
        {
            Data = mappedUsers
        };

        return Task.FromResult(response);
    }
}
