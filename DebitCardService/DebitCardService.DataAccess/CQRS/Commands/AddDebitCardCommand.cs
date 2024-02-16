using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class AddDebitCardCommand : CommandBase<DebitCard, DebitCard>
{
    public override async Task<DebitCard> Execute(DebitCardServiceStorageContext context)
    {
        var debitCardCardNumber = await context.DebitCards.FirstOrDefaultAsync(x => x.CardNumber == Parameter!.CardNumber);
        
        if (debitCardCardNumber != null)
        {
            return null!;
        }

        var debitCardUserId = await context.Users.FirstOrDefaultAsync(x=>x.Id == Parameter!.UserId);

        if (debitCardUserId == null)
        {
            Parameter!.UserId = 0;
            return Parameter;
        }
        
        await context.DebitCards.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
