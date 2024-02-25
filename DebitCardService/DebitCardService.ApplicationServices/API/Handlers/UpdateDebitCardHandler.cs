using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class UpdateDebitCardHandler : IRequestHandler<UpdateDebitCardRequest, UpdateDebitCardResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateDebitCardHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateDebitCardResponse> Handle(UpdateDebitCardRequest request, CancellationToken cancellationToken)
    {
        var debitCardEntity = _mapper.Map<DataAccess.Entities.DebitCard>(request);
        var command = new UpdateDebitCardCommand { Parameter = debitCardEntity };
        var updatedDebitCard = await _commandExecutor.Execute(command);

        if (updatedDebitCard.Id == 0)
        {
            return new UpdateDebitCardResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }

        var domainDebitCard = _mapper.Map<DebitCard>(updatedDebitCard);
        var response = new UpdateDebitCardResponse
        {
            Data = domainDebitCard,
        };
        return response;
    }
}
