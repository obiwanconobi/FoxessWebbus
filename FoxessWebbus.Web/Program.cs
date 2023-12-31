using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FoxessWebbus.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;
using FoxessWebbus.Web.Services;
using Quartz;
using FoxessWebbus.Web.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers();
builder.Services.AddMudServices();


builder.Services.AddQuartz(q =>
{
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("UploadModelBGService");
    q.AddJob<UploadModelBGService>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("RTStats-trigger")
        .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(Convert.ToInt32(SettingsHelper.ReadAppSetting<int>("PollTime")))
            .RepeatForever())
    );


    var jobKey2 = new JobKey("DailyStatisticsService");
    q.AddJob<DailyStatisticsService>(opts => opts.WithIdentity(jobKey2));
   
    q.AddTrigger(optss => optss
        .ForJob(jobKey2)
        .WithIdentity("DailyStats-trigger")
        .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(23, 58))
    ); 
});



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
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


var db = new SqliteContext();
db.Database.Migrate();


//var connectionString = builder.Configuration.GetConnectionString("SqliteDB");
//builder.Services.AddDbContextFactory<SqliteContext>(options => options.UseSqlite(connectionString));
app.Run();
