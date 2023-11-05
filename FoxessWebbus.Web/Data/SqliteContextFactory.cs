using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class SqliteContextFactory : IDesignTimeDbContextFactory<SqliteContext>
{    

    public SqliteContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SqliteContext> optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
            
            string connString = Environment.GetEnvironmentVariable("SqliteDB");
            Console.WriteLine("DB location: " + connString.ToString());
          //  optionsBuilder.UseSqlite(connString);
             string relativePath = @"Data\FoxessWebbus.db";
       
        string connectionString = string.Format("Data Source={0};Version=3;Pooling=True;Max Pool Size=100;", relativePath);
       


        optionsBuilder.UseSqlite(Environment.GetEnvironmentVariable(connectionString));
            return new SqliteContext();
    }
}

