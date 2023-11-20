using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FoxessWebbus.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;
using FoxessWebbus.Web.Services;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddMudServices();


builder.Services.AddQuartz(q =>
{
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("UploadModelBGService");
    q.AddJob<UploadModelBGService>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("RTStats-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 * * ? * *")
    );


    var jobKey2 = new JobKey("DailyStatisticsService");
    q.AddJob<DailyStatisticsService>(opts => opts.WithIdentity(jobKey2));

    q.AddTrigger(optss => optss
        .ForJob(jobKey2)
        .WithIdentity("DailyStats-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("6 58 23 ? * *")
    );
});


//builder.Services.AddQuartz(q =>
//{
//    // Just use the name of your job that you created in the Jobs folder.
//    var jobKey = new JobKey("DailyStatisticsService");
//    q.AddJob<DailyStatisticsService>(opts => opts.WithIdentity(jobKey));

//    q.AddTrigger(opts => opts
//        .ForJob(jobKey)
//        .WithIdentity("SendEmailJob-trigger")
//        //This Cron interval can be described as "run every minute" (when second is zero)
//        .WithCronSchedule("6 59 23 ? * *")
//    );
//});


builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


var db = new SqliteContext();
db.Database.Migrate();


//var connectionString = builder.Configuration.GetConnectionString("SqliteDB");
//builder.Services.AddDbContextFactory<SqliteContext>(options => options.UseSqlite(connectionString));
app.Run();
