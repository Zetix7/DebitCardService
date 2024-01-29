using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DebitCardService.DataAccess;

public class DebitCardServiceStorageContextFactory : IDesignTimeDbContextFactory<DebitCardServiceStorageContext>
{
    public DebitCardServiceStorageContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DebitCardServiceStorageContext>();
        optionBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=DebitCardServiceStorage;Integrated Security=True;Encrypt=False");
        return new DebitCardServiceStorageContext(optionBuilder.Options);
    }
}
