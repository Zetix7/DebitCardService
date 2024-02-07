using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class RemoveUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(DebitCardServiceStorageContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Parameter!.Id);
        if (user == null)
        {
            return Parameter!;
        }
        else
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
