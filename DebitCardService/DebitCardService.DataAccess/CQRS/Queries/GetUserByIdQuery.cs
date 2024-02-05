using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess.CQRS.Queries;

public class GetUserByIdQuery : QueryBase<User>
{
    public int Id { get; set; }

    public override Task<User> Execute(DebitCardServiceStorageContext context)
    {
        return context.Users.FirstOrDefaultAsync(x=>x.Id == Id)!;
    }
}
