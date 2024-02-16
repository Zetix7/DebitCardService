using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class AddHistoryCommand : CommandBase<History, History>
{
    public override async Task<History> Execute(DebitCardServiceStorageContext context)
    {
        var debitCard = await context.DebitCards.FirstOrDefaultAsync(x => x.Id == Parameter!.DebitCardId);

        if (debitCard == null)
        {
            return null!;
        }

        var history = await context.DebitCards
            .FirstOrDefaultAsync(x => x.Id == debitCard.Id && x.AccountNumber == Parameter!.SenderAccountNumber);

        if (history == null)
        {
            Parameter!.Id = 0;
            return Parameter;
        }

        await context.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
