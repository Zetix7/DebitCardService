using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetAllHistoryQuery : QueryBase<List<History>>
{
    public override Task<List<History>> Execute(DebitCardServiceStorageContext context)
    {
        return context.History.ToListAsync();
    }
}
