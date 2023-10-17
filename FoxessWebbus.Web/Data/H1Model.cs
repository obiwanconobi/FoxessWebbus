namespace FoxessWebbus.Web.Data;

public class H1Model
{
    public short PVPower1 {get;set;}
    public short PVPower2 {get;set;}
    public short PVPowerTotal {get; set;} 
    public short BatteryChargeRate { get; set; }
    public short BatterySoc { get; set; }
    public short BatteryTemp { get; set; }
    public short InverterTemp { get; set; }

  
    public DateTime LoggedDateTime { get; set; }
}
