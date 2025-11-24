using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoMarketApp.Infrastructure.Data;

internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AutoMarketAppDbContext>
{
    public AutoMarketAppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AutoMarketAppDbContext>()
            .UseNpgsql("Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;")
            .Options;
        
        return new AutoMarketAppDbContext(options);
    }
}