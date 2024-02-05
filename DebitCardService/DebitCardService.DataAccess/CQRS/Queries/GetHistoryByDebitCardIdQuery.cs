using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetHistoryByDebitCardIdQuery : QueryBase<List<History>>
{
    public int DebitCardId { get; set; }

    public override Task<List<History>> Execute(DebitCardServiceStorageContext context)
    {
        return context.History.Where(x=>x.DebitCardId == DebitCardId).ToListAsync();
    }
}
