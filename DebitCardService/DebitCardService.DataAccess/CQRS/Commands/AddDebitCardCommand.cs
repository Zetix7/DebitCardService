using DebitCardService.DataAccess.Entities;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class AddDebitCardCommand : CommandBase<DebitCard, DebitCard>
{
    public override async Task<DebitCard> Execute(DebitCardServiceStorageContext context)
    {
        var debitCard = context.DebitCards.Where(x => x.CardNumber == Parameter!.CardNumber);
        
        if (debitCard.Any())
        {
            return null!;
        }
        
        await context.DebitCards.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
