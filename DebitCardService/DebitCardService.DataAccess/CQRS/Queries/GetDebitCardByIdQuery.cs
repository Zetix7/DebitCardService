using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetDebitCardByIdQuery : QueryBase<DebitCard>
{
    public int Id { get; set; }

    public override Task<DebitCard> Execute(DebitCardServiceStorageContext context)
    {
        return context.DebitCards.FirstOrDefaultAsync(x => x.Id == Id)!;
    }
}
