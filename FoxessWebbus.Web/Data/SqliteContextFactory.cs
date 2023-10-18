using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class SqliteContextFactory : IDesignTimeDbContextFactory<SqliteContext>
{    

    public SqliteContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SqliteContext> optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
            
            string connString = Environment.GetEnvironmentVariable("SqliteDB");
            optionsBuilder.UseSqlite(connString);
            
            return new SqliteContext();
    }
}

