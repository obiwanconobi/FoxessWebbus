﻿using FoxessWebbus.Web.Data;
using RICADO.Modbus;
using System.Diagnostics;
using static MudBlazor.Colors;
using Quartz;
using System.Runtime.Versioning;
using MudBlazor;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FoxessWebbus.Web.Shared;

namespace FoxessWebbus.Web.Services
{
    
    public class UploadModelBGService : IJob
    {
        public short total = 0;
        UploadModelData upload = new UploadModelData();
        ErrorLogService errorLog = new ErrorLogService();

        List<ushort> RegisterNumbersList = new List<ushort>(){
            31002,31005,31022,31022,31024,31023,31018,31014,31014
        };

        public async Task Execute(IJobExecutionContext context)
        {
            int count = 0;

            while(count < 6) 
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                await Upload();
                timer.Stop();
                Console.WriteLine("Time Taken for Get Data to DB: " + timer.Elapsed);
                count++;
                Thread.Sleep(10000);
            }
            Console.WriteLine("Run through complete");
        }

         

        public async Task Upload()
        {
            /* var model = new H1Model()
            {
                PVPower1 = await GetData(31002),
                PVPower2 = await GetData(31005),
                BatteryCharge = await RelativeZero(31022, true),
                BatteryDischarge = await RelativeZero(31022, false),
                BatterySoc = await GetData(31024),
                BatteryTemp = await FormatTemp(31023),
                InverterTemp = await FormatTemp(31018),
                FeedIn = await RelativeZero(31014, true),
                FromGrid = await RelativeZero(31014, false)
            }; */

            var model = await GetData(RegisterNumbersList);

            model.PVPowerTotal += model.PVPower1;
            model.PVPowerTotal += model.PVPower2;
            model.LoggedDateTime = DateTime.Now;

            upload.UploadData(model);
        }

        private async Task<short> PVTotal(H1Model fromModel)
        {
            await Task.Delay(1);
            total = 0;
            total += fromModel.PVPower1;
            total += fromModel.PVPower2;
            return total;
        }

    
        private async Task<H1Model> GetData(List<ushort> registerNumbers)
        {
            H1Model returnModel = new H1Model();
            try
            {       

                using (ModbusRTUDevice device = new ModbusRTUDevice(247, ConnectionMethod.TCP, SettingsHelper.ReadAppSetting<string>("ModbusIP"), 502, 600, 5))
                {

                    ReadRegistersResult data = new ReadRegistersResult();
                    Stopwatch timer = new Stopwatch();
                    await device.InitializeAsync(CancellationToken.None);
                    
                    int count = 0;
                    
                    var data22 = await device.ReadHoldingRegistersAsync(32005, 1, CancellationToken.None);


                    foreach(var registerNumber in registerNumbers)
                    {
                        timer.Start();
                        try
                        {
                            data = await device.ReadHoldingRegistersAsync(registerNumber, 1, CancellationToken.None);
                               // if(data.Values !=)
                            
                        }
                        catch (Exception ex)
                        {
                            errorLog.LogError(ex.ToString(), "Register number:" + registerNumber.ToString() + " :: Packets sent: " + data.PacketsSent.ToString() + " :: Number of tries: " + "  Duration: " + data.Duration.ToString());    
                        }

                        timer.Stop();
                        Console.WriteLine("Time taken for " + registerNumber + ": " + timer.Elapsed + "  Duration: " + data.Duration.ToString());
                            

                        

                        if(data.Values != null)
                        {
                            foreach(var value in data.Values){
                                returnModel.SetValue(count, value);
                            }
                            
                            
                        } 
                        count++;
                    }
                    device.Dispose();
                    
                }
                
                return returnModel;
            }catch(Exception ex){
                errorLog.LogError(ex.ToString(), "UploadModelBGService");
                return returnModel;
            }
           
        }

     
    }
}
