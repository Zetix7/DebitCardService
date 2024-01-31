using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;
using DebitCardService.DataAccess;
using MediatR;

namespace DebitCardService.ApplicationServices.API.Handlers;

public class GetAllHistoryHandler : IRequestHandler<GetAllHistoryRequest, GetAllHistoryResponse>
{
    private readonly IRepository<DataAccess.Entities.History> _historyRepository;

    public GetAllHistoryHandler(IRepository<DataAccess.Entities.History> historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public Task<GetAllHistoryResponse> Handle(GetAllHistoryRequest request, CancellationToken cancellationToken)
    {
        var history = _historyRepository.GetAll();
        var domainHistory = history.Select(x => new History
        {
            Id = x.Id,
            DateOfOperation = x.DateOfOperation,
            Sender = x.Sender,
            SenderAccountNumber = x.SenderAccountNumber,
            Recipient = x.Recipient,
            RecipientAccountNumber = x.RecipientAccountNumber,
            Amount = x.Amount,
            Title = x.Title,
        }).ToList();

        var response = new GetAllHistoryResponse
        {
            Data = domainHistory,
        };

        return Task.FromResult(response);
    }
}
