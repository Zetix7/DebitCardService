using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetUsersQuery : QueryBase<List<User>>
{
    public string? Login { get; set; }

    public override Task<List<User>> Execute(DebitCardServiceStorageContext context)
    {
        return string.IsNullOrEmpty(Login) 
            ? context.Users.Include(x=>x.DebitCards).ToListAsync() 
            : context.Users.Include(x => x.DebitCards).Where(x => x.Login == Login).ToListAsync();
    }
}
