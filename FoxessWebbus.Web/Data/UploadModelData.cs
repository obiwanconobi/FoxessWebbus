using FoxessWebbus.Web.Data;
using FoxessWebbus.Web.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;

public class UploadModelData{

    private SqliteContext? _context;
    private ErrorLogService? _errorLogger;

    public UploadModelData(){
       //_context ??= await EmployeeDataContextFactory.CreateDbContextAsync();
      
    }

    public async void UploadData(H1Model model){
         _context ??= new SqliteContext();

       using (var context  = new SqliteContext()){
           H1ModelDb dbModel = new H1ModelDb(){
               EntryId = Guid.NewGuid(),
               PVPower1 = model.PVPower1,
               PVPower2 = model.PVPower2,
               PVPowerTotal = model.PVPowerTotal,
               BatteryCharge = model.BatteryCharge,
               BatteryDischarge = model.BatteryDischarge,
               BatterySoc = model.BatterySoc,
               BatteryTemp = model.BatteryTemp,
               InverterTemp = model.InverterTemp,
               FeedIn = model.FeedIn,
               FromGrid = model.FromGrid,
               LoggedDateTime = DateTime.Now

            };
            
            
            try{
                context.FoxH1.Add(dbModel);
                await context.SaveChangesAsync();

            }
            catch(Exception ex){
                _errorLogger = new ErrorLogService();

                _errorLogger.LogError(ex.ToString(), "UploadModelData");
                Console.WriteLine(ex.ToString());
            }
            
       }
    }
}