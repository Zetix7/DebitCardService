using DebitCardService.DataAccess.Entities;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class AddHistoryCommand : CommandBase<History, History>
{
    public override async Task<History> Execute(DebitCardServiceStorageContext context)
    {
        await context.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
