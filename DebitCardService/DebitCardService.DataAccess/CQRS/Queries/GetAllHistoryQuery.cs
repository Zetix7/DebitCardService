using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetAllHistoryQuery : QueryBase<List<History>>
{
    public decimal Amount { get; set; }

    public override Task<List<History>> Execute(DebitCardServiceStorageContext context)
    {
        return Amount > 0
            ? context.History.Where(x => x.Amount > Amount).ToListAsync()
            : context.History.ToListAsync();
    }
}
