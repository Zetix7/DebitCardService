using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class UpdateDebitCardCommand : CommandBase<DebitCard, DebitCard>
{
    public override async Task<DebitCard> Execute(DebitCardServiceStorageContext context)
    {
        var debitCard = await context.DebitCards.FirstOrDefaultAsync(x => x.Id == Parameter!.Id);
        if (debitCard == null)
        {
            Parameter!.Id = 0;
            return Parameter!;
        }

        if (Parameter!.PinCode != debitCard.PinCode)
        {
            debitCard.PinCode = Parameter.PinCode;
        }

        if (Parameter!.IsActive != debitCard.IsActive)
        {
            debitCard.IsActive = Parameter.IsActive;
        }

        if (Parameter!.IsActiveCashWithdrawal != debitCard.IsActiveCashWithdrawal)
        {
            debitCard.IsActiveCashWithdrawal = Parameter.IsActiveCashWithdrawal;
        }

        if (Parameter!.CashWithdrawalLimit != debitCard.CashWithdrawalLimit)
        {
            debitCard.CashWithdrawalLimit = Parameter.CashWithdrawalLimit;
        }

        if (Parameter!.IsActiveByPayPass != debitCard.IsActiveByPayPass)
        {
            debitCard.IsActiveByPayPass = Parameter.IsActiveByPayPass;
        }

        if (Parameter!.PayPassLimit != debitCard.PayPassLimit)
        {
            debitCard.PayPassLimit = Parameter.PayPassLimit;
        }

        if (Parameter!.IsActiveByPhone != debitCard.IsActiveByPhone)
        {
            debitCard.IsActiveByPhone = Parameter.IsActiveByPhone;
        }

        if (Parameter!.PhoneLimit != debitCard.PhoneLimit)
        {
            debitCard.PhoneLimit = Parameter.PhoneLimit;
        }

        await context.SaveChangesAsync();
        return debitCard;
    }
}
