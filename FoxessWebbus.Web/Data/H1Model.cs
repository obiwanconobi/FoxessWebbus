namespace FoxessWebbus.Web.Data;

public class H1Model
{
    public short PVPower1 {get;set;}
    public decimal PV1Amps { get; set; }
    public decimal PV1Voltage { get; set; }
    public short PVPower2 {get;set;}
    public decimal PV2Amps { get; set; } 
    public decimal PV2Voltage { get; set;}
    public short PVPowerTotal {get; set;} 
    public short BatteryCharge { get; set; }
    public short BatteryDischarge {get;set;}
    public short BatterySoc { get; set; }
    public short BatteryTemp { get; set; }
    public short InverterTemp { get; set; }
    public short FeedIn {get;set;}
    public short FromGrid {get;set;}
    public DateTime LoggedDateTime { get; set; }


    public void SetValue(int count, short val){

        switch (count) 
        {
            case 0:
                PVPower1 = val;
                break;
            case 1:
                PVPower2 = val;
                break;
            case 2:
                BatteryCharge = RelativeZero(val, true);
                break;
            case 3:
                BatteryDischarge = RelativeZero(val, false);
                break;
            case 4:
                BatterySoc = val;
                break;
            case 5:
                BatteryTemp = FormatTemp(val);
                break;
            case 6:
                InverterTemp = FormatTemp(val);
                break;
            case 7:
                FeedIn = RelativeZero(val, false);
                break;
            case 8:
                FromGrid = RelativeZero(val, true);
                break;
            case 9:
                PV1Amps = FormatDivide10(val);
                break;
            case 10:
                PV1Voltage = FormatDivide10(val);
                break;
            case 11:
                PV2Amps = FormatDivide10(val);
                break;
            case 12:
                PV2Voltage = FormatDivide10(val);
                break;

        }

    }


    private decimal FormatDivide10(short val)
    {
        return Convert.ToDecimal(val) / 10;
    }

    private short FormatTemp(short val)
        {
            
            if (val.ToString().Length > 2)
            {
                val /= 10;
                return val;
            }

            return val;

        }


    private short RelativeZero(short val, bool aboveZero)
    {

            //var result = await GetData(registerNumber);
            if (val > 0 && aboveZero == false)
            {
                return val;
            }
            else if (val < 0 && aboveZero == true)
            {
                val *= -1;
                return val;
            }

            return 0;

        }    



}
