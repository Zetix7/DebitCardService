using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetAllDebitCardsQuery : QueryBase<List<DebitCard>>
{
    public override Task<List<DebitCard>> Execute(DebitCardServiceStorageContext context)
    {
        return context.DebitCards.ToListAsync();
    }
}
