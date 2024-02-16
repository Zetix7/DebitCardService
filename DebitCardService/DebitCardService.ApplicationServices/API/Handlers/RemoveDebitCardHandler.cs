using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class RemoveDebitCardHandler : IRequestHandler<RemoveDebitCardRequest, RemoveDebitCardResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public RemoveDebitCardHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<RemoveDebitCardResponse> Handle(RemoveDebitCardRequest request, CancellationToken cancellationToken)
    {
        var debitCardEntity = new DataAccess.Entities.DebitCard
        {
            Id = request.Id
        };
        var command = new RemoveDebitCardCommand { Parameter = debitCardEntity };
        var removedDebitCard = await _commandExecutor.Execute(command);

        if (removedDebitCard.Id == 0)
        {
            return new RemoveDebitCardResponse { Error = new ErrorModel(ErrorType.NotFound) };
        }

        var domainDebitCard = _mapper.Map<DebitCard>(removedDebitCard);
        var response = new RemoveDebitCardResponse
        {
            Data = domainDebitCard
        };
        return response;
    }
}
