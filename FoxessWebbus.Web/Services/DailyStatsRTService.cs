using FoxessWebbus.Web.Data;
using Quartz;
using RICADO.Modbus;
using System.Diagnostics;
using ntfy;
using ntfy.Requests;
using ntfy.Actions;
using FoxessWebbus.Web.Shared;

namespace FoxessWebbus.Web.Services
{
    public class DailyStatsRTService
    {

        public async Task<H1DailyModel> GetData(List<ushort> registerNumbers)
        {
            ErrorLogService errorLog = new ErrorLogService();

            H1DailyModel returnModel = new H1DailyModel();
            try
            {

                using (ModbusRTUDevice device = new ModbusRTUDevice(247, ConnectionMethod.TCP, SettingsHelper.ReadAppSetting<string>("ModbusIP"), 502, 600, 5))
                {

                    ReadRegistersResult data = new ReadRegistersResult();
                    Stopwatch timer = new Stopwatch();
                    await device.InitializeAsync(CancellationToken.None);

                    int count = 0;
                    

                    foreach (var registerNumber in registerNumbers)
                    {
                        int errorCount = 0;
                        bool success = false;
                        timer.Start();
                        while(!success && errorCount < 4){
                            try
                            {
                                data = await device.ReadHoldingRegistersAsync(registerNumber, 1, CancellationToken.None);
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                errorCount++;
                                errorLog.LogError("Error gettting data for DailyStatsRTService for register number: " + registerNumber + " :: Error Count: " + errorCount, "DailyStatsRTService");
                            }
                        }
                        
                        success = false;
    

                        timer.Stop();
                        Console.WriteLine("Time taken for " + registerNumber + ": " + timer.Elapsed + "  Duration: " + data.Duration.ToString());




                        if (data.Values != null)
                        {
                            foreach (var value in data.Values)
                            {
                                returnModel.SetValue(count, value);
                            }


                        }
                        count++;
                    }
                    device.Dispose();

                }

                return returnModel;
            }
            catch (Exception ex)
            {
                errorLog.LogError(ex.ToString(), "DAILY UPLOAD SERVICE");
                return returnModel;
            }

        }


    }

}