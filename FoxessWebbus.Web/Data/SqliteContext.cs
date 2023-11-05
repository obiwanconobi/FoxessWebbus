using FoxessWebbus.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
        Console.WriteLine("DB location: " + test.ToString());
    //    var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
      //  string curdir = Directory.GetCurrentDirectory();
     //   string relativePath = @"Data\FoxessWebbus.db";
       
       // string connectionString = string.Format("Data Source={0};Version=3;Pooling=True;Max Pool Size=100;", path.Replace("file:\\", "") + "\\" + relativePath);
       


        optionsBuilder.UseSqlite(test);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<H1ModelDb>().HasKey(x => x.EntryId);
    }

    //public DbSet<Employee> Employees{ get; set; }
    public DbSet<H1ModelDb> FoxH1 {get;set;}

}

