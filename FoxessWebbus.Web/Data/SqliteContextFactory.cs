using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class SqliteContextFactory : IDesignTimeDbContextFactory<SqliteContext>
{    

    public SqliteContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SqliteContext> optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
            
         
             string relativePath = @"Data\FoxessWebbus.db";
       
        string connectionString = string.Format("Data Source={0};", relativePath);
       


        optionsBuilder.UseSqlite(Environment.GetEnvironmentVariable(connectionString));
            return new SqliteContext();
    }
}

