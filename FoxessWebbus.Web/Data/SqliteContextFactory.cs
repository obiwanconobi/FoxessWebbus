using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class SqliteContextFactory : IDesignTimeDbContextFactory<SqliteContext>
{    

    public SqliteContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SqliteContext> optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();

        var test = Environment.GetEnvironmentVariable("SqliteDB");
        Console.WriteLine("DB location: " + test.ToString());

      //  string test = @"Data\FoxessWebbus.db";
       // string connectionString = string.Format("Data Source={0};", test);
       // optionsBuilder.UseSqlite(connectionString);
        


        optionsBuilder.UseSqlite(Environment.GetEnvironmentVariable("SqliteDB"));
            return new SqliteContext();
    }
}

