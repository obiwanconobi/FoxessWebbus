using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class SqliteContextFactory : IDesignTimeDbContextFactory<SqliteContext>
{    

    public SqliteContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SqliteContext> optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
            
            string connString = Environment.GetEnvironmentVariable("SqliteDB");
            Console.WriteLine("DB location: " + connString.ToString());
            optionsBuilder.UseSqlite(connString);
            
            return new SqliteContext();
    }
}

