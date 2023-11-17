namespace FoxessWebbus.Web.Data
{
    public class H1DailyModel
    {

        public Guid EntryId { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Solar { get; set; }
        public decimal Grid { get; set; }
        public decimal Feed { get; set; }
        public decimal BatteryCharge { get; set; }
        public decimal BatteryDischarge { get; set; }
        public decimal Yield { get; set; }
        public decimal Load { get; set; }

        public void SetValue(int count, short val)
        {
            switch (count)
            {
                case 0:
                    Solar = val;
                    Solar /= 10;
                    break;
                case 1:
                    Grid = val;
                    Grid /= 10;
                    break;
                case 2:
                    Feed = val;
                    Feed /= 10;
                    break;
                case 3:
                    BatteryCharge = val;
                    BatteryCharge /= 10;
                    break;
                case 4:
                    BatteryDischarge = val;
                    BatteryDischarge /= 10;
                    break;
                case 5:
                    Yield = val;
                    Yield /= 10;
                    break;
                case 6:
                    Load = val;
                    Load /= 10;
                    break;
            }


        }
    }
}
