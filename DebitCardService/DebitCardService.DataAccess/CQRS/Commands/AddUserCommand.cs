using DebitCardService.DataAccess.Entities;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class AddUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(DebitCardServiceStorageContext context)
    {
        await context.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
