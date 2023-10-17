namespace FoxessWebbus.Web.Data;

public class H1Model
{
    public short PVPower1 {get;set;}
    public short PVPower2 {get;set;}
    public short PVPowerTotal {get; set;} 
    public short BatteryCharge { get; set; }
    public short BatteryDischarge {get;set;}
    public short BatterySoc { get; set; }
    public short BatteryTemp { get; set; }
    public short InverterTemp { get; set; }
    public short FeedIn {get;set;}
    public short FromGrid {get;set;}


  
    public DateTime LoggedDateTime { get; set; }
}
