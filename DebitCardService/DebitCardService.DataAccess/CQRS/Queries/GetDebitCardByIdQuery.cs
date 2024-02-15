using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetDebitCardByIdQuery : QueryBase<DebitCard>
{
    public int Id { get; set; }

    public override Task<DebitCard> Execute(DebitCardServiceStorageContext context)
    {
        return context.DebitCards.Include(x => x.History).FirstOrDefaultAsync(x => x.Id == Id)!;
    }
}
