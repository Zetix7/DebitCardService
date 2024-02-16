using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class AddHistoryHandler : IRequestHandler<AddHistoryRequest, AddHistoryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddHistoryHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddHistoryResponse> Handle(AddHistoryRequest request, CancellationToken cancellationToken)
    {
        var historyEntity = _mapper.Map<DataAccess.Entities.History>(request);
        var command = new AddHistoryCommand { Parameter = historyEntity };
        var history = await _commandExecutor.Execute(command);

        if (history == null)
        {
            return new AddHistoryResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }

        if( history.Id == 0)
        {
            return new AddHistoryResponse { Error = new ErrorModel(ErrorType.ValidationError) };
        }

        var domainHistory = _mapper.Map<History>(history);
        var response = new AddHistoryResponse
        {
            Data = domainHistory,
        };
        return response;
    }
}
