using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class RemoveDebitCardCommand : CommandBase<DebitCard, DebitCard>
{
    public override async Task<DebitCard> Execute(DebitCardServiceStorageContext context)
    {
        var debitCard = await context.DebitCards.FirstOrDefaultAsync(x => x.Id == Parameter!.Id);
        if (debitCard == null)
        {
            return Parameter!;
        }
        else
        {
            context.DebitCards.Remove(debitCard!);
            await context.SaveChangesAsync();
            return debitCard!;
        }
    }
}
