using FoxessWebbus.Web.Data;
using RICADO.Modbus;
using System.Diagnostics;
using static MudBlazor.Colors;
using Quartz;
using System.Runtime.Versioning;

namespace FoxessWebbus.Web.Services
{
    
    public class UploadModelBGService : IJob
    {
        public short total = 0;
        UploadModelData upload = new UploadModelData();

        public async Task Execute(IJobExecutionContext context)
        {
            int count = 0;

            while(count < 6) 
            {
                await Upload();
                count++;
            }
            Console.WriteLine("Run through complete");
        }


        public async Task Upload()
        {
            var model = new H1Model()
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
            };
            model.PVPowerTotal = await PVTotal(model);
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

        //Simply divides by 10 to get the temp in correct format
        private async Task<short> FormatTemp(ushort registerNumber)
        {
            var result = await GetData(registerNumber);
            if (result.ToString().Length > 2)
            {
                result /= 10;
                return result;
            }

            return result;

        }

        private async Task<short> GetData(ushort registerNumber)
        {

            try
            {
                using (ModbusRTUDevice device = new ModbusRTUDevice(247, ConnectionMethod.TCP, "192.168.1.11", 502, 500, 5))
                {
                    Stopwatch timer = new Stopwatch();
                    await device.InitializeAsync(CancellationToken.None);
                    timer.Start();
                    ReadRegistersResult data = await device.ReadHoldingRegistersAsync(registerNumber, 1, CancellationToken.None);
                    timer.Stop();
                    Console.WriteLine("Time taken for " + registerNumber + ": " + timer.Elapsed);
                    foreach (var value in data.Values)
                    {
                        return value;
                        // Console.Write(value);
                    }
                    return 0;
                }
            }catch(Exception ex) 
            {
                Console.WriteLine("Error when getting data");
                Console.WriteLine(ex.ToString());
                return 0;
            }

           
        }


        // This is a hacky method which returns the value only if it is either above or below zero.
        // Because some values share a register and can be minus
        private async Task<short> RelativeZero(ushort registerNumber, bool aboveZero)
        {

            var result = await GetData(registerNumber);
            if (result > 0 && aboveZero == false)
            {
                return result;
            }
            else if (result < 0 && aboveZero == true)
            {
                result *= -1;
                return result;
            }

            return 0;

        }

     
    }
}
