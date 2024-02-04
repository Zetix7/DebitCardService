using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class AddDebitCardHandler : IRequestHandler<AddDebitCardRequest, AddDebitCardResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddDebitCardHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddDebitCardResponse> Handle(AddDebitCardRequest request, CancellationToken cancellationToken)
    {
        var debitCardEntity = _mapper.Map<DataAccess.Entities.DebitCard>(request);
        var command = new AddDebitCardCommand { Parameter = debitCardEntity };
        var debitCard = await _commandExecutor.Execute(command);
        var domainDebitCard = _mapper.Map<DebitCard>(debitCard);
        var response = new AddDebitCardResponse
        {
            Data = domainDebitCard
        };
        return response;
    }
}
