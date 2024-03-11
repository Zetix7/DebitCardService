using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class UpdateUserByIdCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(DebitCardServiceStorageContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Parameter!.Id);
        if (user == null)
        {
            return Parameter!;
        }

        if (user.FirstName == Parameter!.FirstName && user.LastName == Parameter!.LastName)
        {
            Parameter!.Id = 0;
            return Parameter;
        }

        if (!string.IsNullOrEmpty(Parameter!.FirstName))
        {
            user!.FirstName = Parameter!.FirstName;
        }

        if (!string.IsNullOrEmpty(Parameter!.LastName))
        {
            user!.LastName = Parameter!.LastName;
        }

        if (Parameter!.AccessLevel != user.AccessLevel)
        {
            user!.AccessLevel = Parameter!.AccessLevel;
        }

        if (!string.IsNullOrEmpty(Parameter!.HashedPassword))
        {
            user!.HashedPassword = Parameter!.HashedPassword;
        }

        if (Parameter!.IsActive != user.IsActive)
        {
            user!.IsActive = Parameter!.IsActive;
        }

        await context.SaveChangesAsync();
        return user;
    }
}
