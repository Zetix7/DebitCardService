using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.ApplicationServices.API.ErrorHandling;
using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class AddDebitCardHandler : IRequestHandler<AddDebitCardRequest, AddDebitCardResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly ILogger<AddDebitCardHandler> _logger;

    public AddDebitCardHandler(IMapper mapper, ICommandExecutor commandExecutor, ILogger<AddDebitCardHandler> logger)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _logger = logger;
        logger.LogInformation("We are in AddDebitCardHandler class");
    }

    public async Task<AddDebitCardResponse> Handle(AddDebitCardRequest request, CancellationToken cancellationToken)
    {
        var debitCardEntity = _mapper.Map<DataAccess.Entities.DebitCard>(request);
        var command = new AddDebitCardCommand { Parameter = debitCardEntity };
        var debitCard = await _commandExecutor.Execute(command);

        if (debitCard == null)
        {
            _logger.LogError("Wrong CardNumber - it is exist in database! Validation Error occured");
            return new AddDebitCardResponse { Error = new ErrorModel(ErrorType.ValidationError) };
        }

        if (debitCard.Id == 0)
        {
            return new AddDebitCardResponse { Error = new ErrorModel(ErrorType.InternalServerError) };
        }

        var domainDebitCard = _mapper.Map<DebitCard>(debitCard);
        var response = new AddDebitCardResponse
        {
            Data = domainDebitCard
        };
        return response;
    }
}
