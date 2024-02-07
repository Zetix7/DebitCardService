using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class UpdateDebitCardActivityHandler : IRequestHandler<UpdateDebitCardActivityRequest, UpdateDebitCardActivityResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateDebitCardActivityHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateDebitCardActivityResponse> Handle(UpdateDebitCardActivityRequest request, CancellationToken cancellationToken)
    {
        var debitCardEntity = _mapper.Map<DataAccess.Entities.DebitCard>(request);
        var command = new UpdateDebitCardActivityCommand { Parameter = debitCardEntity };
        var updatedDebitCard = await _commandExecutor.Execute(command);
        var domainDebitCard = _mapper.Map<DebitCard>(updatedDebitCard);
        var response = new UpdateDebitCardActivityResponse
        {
            Data = domainDebitCard,
        };
        return response;
    }
}
