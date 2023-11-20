using FoxessWebbus.Web.Data;

namespace FoxessWebbus.Web.Services
{
    public class GetDailyStatisticsService
    {

        SqliteContext _context;

        public List<H1DailyModel> GetData()
        {
            using (var context = new SqliteContext())
            {
                var result = context.DailyH1.OrderByDescending(x => x.EntryDate).ToList();
                return result;
            }
        }
    }
}
