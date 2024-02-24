﻿using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Commands;

public class UpdateUserNameByIdCommand : CommandBase<User, User>
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

        if (!string.IsNullOrEmpty(Parameter!.Password))
        {
            user!.Password = Parameter!.Password;
        }

        await context.SaveChangesAsync();
        return user;
    }
}
