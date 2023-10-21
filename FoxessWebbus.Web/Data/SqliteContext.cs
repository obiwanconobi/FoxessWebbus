using FoxessWebbus.Web.Data;
using Microsoft.EntityFrameworkCore;
public class SqliteContext : DbContext
{
   // protected readonly IConfiguration Configuration;

    //public SqliteContext(IConfiguration configuration)
    //{
    //Configuration = configuration;
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var test = Environment.GetEnvironmentVariable("SqliteDB");
        optionsBuilder.UseSqlite(Environment.GetEnvironmentVariable("SqliteDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<H1ModelDb>().HasKey(x => x.EntryId);
    }

    //public DbSet<Employee> Employees{ get; set; }
   // public DbSet<H1ModelDb> FoxH1 {get;set;}

}

