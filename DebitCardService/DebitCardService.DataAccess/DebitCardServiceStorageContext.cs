using DebitCardService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebitCardService.DataAccess;

public class DebitCardServiceStorageContext : DbContext
{
    public DebitCardServiceStorageContext(DbContextOptions<DebitCardServiceStorageContext> options) : base(options)
    {
    }

    public DbSet<DebitCard> DebitCards { get; set; }
}
