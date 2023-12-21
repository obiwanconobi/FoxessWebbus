using FoxessWebbus.Web.Data;
using Quartz;
using RICADO.Modbus;
using System.Diagnostics;

namespace FoxessWebbus.Web.Services
{
    public class DailyStatisticsService : IJob
    {
        UploadDailyData upload = new UploadDailyData();
        ErrorLogService errorLog = new ErrorLogService();
        DailyStatsRTService RTService = new DailyStatsRTService();
        NTFYService ntfyService = new NTFYService();

        List<ushort> RegisterNumbersList = new List<ushort>(){
            32002,32014,32011,32005, 32008, 32017,32023
        };
        public async Task Execute(IJobExecutionContext context)
        {

           // H1DailyModel model = await  GetData(RegisterNumbersList);
           H1DailyModel model = await RTService.GetData(RegisterNumbersList);
            model.EntryDate = DateTime.Now;
            model.EntryId = Guid.NewGuid();

            upload.UploadData(model);

            string messageText = "Solar Total: " + model.Solar + " ¦  Grid Total: " + model.Grid;
            await ntfyService.SendNotification(messageText);

        }

    


    }
}
