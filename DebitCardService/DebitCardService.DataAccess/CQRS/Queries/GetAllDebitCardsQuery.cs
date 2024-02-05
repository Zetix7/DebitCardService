using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetAllDebitCardsQuery : QueryBase<List<DebitCard>>
{
    public int UserId { get; set; }

    public override Task<List<DebitCard>> Execute(DebitCardServiceStorageContext context)
    {
        return UserId == 0
            ? context.DebitCards.ToListAsync()
            : context.DebitCards.Where(x=>x.UserId == UserId).ToListAsync();
    }
}
