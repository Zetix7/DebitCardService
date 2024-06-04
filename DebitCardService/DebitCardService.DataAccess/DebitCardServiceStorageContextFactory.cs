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

// I5e1S7EEKkY1NpMxuZUcfi
// Server=tcp:debit-card-service.database.windows.net,1433;Initial Catalog=DebitCardServiceStorage;Persist Security Info=False;User ID=greg;Password=I5e1S7EEKkY1NpMxuZUcfi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;