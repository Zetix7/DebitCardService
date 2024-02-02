using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetAllHistoryHandler : IRequestHandler<GetAllHistoryRequest, GetAllHistoryResponse>
{
    private readonly IRepository<DataAccess.Entities.History> _historyRepository;
    private readonly IMapper _mapper;

    public GetAllHistoryHandler(IRepository<DataAccess.Entities.History> historyRepository, IMapper mapper)
    {
        _historyRepository = historyRepository;
        _mapper = mapper;
    }

    public async Task<GetAllHistoryResponse> Handle(GetAllHistoryRequest request, CancellationToken cancellationToken)
    {
        var history = await _historyRepository.GetAll();
        var mappedHistory = _mapper.Map<List<History>>(history);

        var response = new GetAllHistoryResponse
        {
            Data = mappedHistory,
        };

        return response;
    }
}
