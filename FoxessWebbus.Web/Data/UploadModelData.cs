using FoxessWebbus.Web.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;

public class UploadModelData{

    private SqliteContext? _context;

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
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT name from sqlite_master WHERE type='table'";
                    context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            Console.WriteLine(result.GetString(0));
                        }
                    }
                }
            }catch(Exception ex){
                Console.WriteLine("Error listing tables");
            }


            try{
            context.FoxH1.Add(dbModel);
            await context.SaveChangesAsync();
            }catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }
            
       }
    }
}