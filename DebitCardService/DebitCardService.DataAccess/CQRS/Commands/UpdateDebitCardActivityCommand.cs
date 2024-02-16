using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class UpdateDebitCardActivityCommand : CommandBase<DebitCard, DebitCard>
{
    public override async Task<DebitCard> Execute(DebitCardServiceStorageContext context)
    {
        var debitCard = await context.DebitCards.FirstOrDefaultAsync(x => x.Id == Parameter!.Id);
        if (debitCard == null)
        {
            Parameter!.Id = 0;
            return Parameter!;
        }

        if (Parameter!.IsActive != debitCard.IsActive)
        {
            debitCard.IsActive = Parameter.IsActive;
        }

        await context.SaveChangesAsync();
        return debitCard;
    }
}
