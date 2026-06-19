
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.Infrastructure;

public class SpyContextFactory : IDesignTimeDbContextFactory<SpyContext>
{
    public SpyContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<SpyContext>();

        var host = Environment.GetEnvironmentVariable("DB_HOST");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var dtbs = Environment.GetEnvironmentVariable("DB_DB");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var pass = Environment.GetEnvironmentVariable("DB_PASS");
        
        var conn = $"Server={host};Port={port};Database={dtbs};Uid={user};Pwd={pass};";
        options.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 0)));

        return new SpyContext(options.Options);
    }
}