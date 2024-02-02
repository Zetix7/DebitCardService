using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetUsersQuery : QueryBase<List<User>>
{
    public override Task<List<User>> Execute(DebitCardServiceStorageContext context)
    {
        return context.Users.ToListAsync();
    }
}
