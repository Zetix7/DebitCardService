using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class AddUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(DebitCardServiceStorageContext context)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.FirstName == Parameter!.FirstName && x.LastName == Parameter.LastName || x.Login == Parameter.Login);
        if (user != null)
        {
            return null!;
        }
        await context.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
