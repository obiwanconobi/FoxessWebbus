

using System.Runtime.CompilerServices;
using FoxessWebbus.Web.Data;

namespace FoxessWebbus.Web.Services
{
    public class GetHistoryBetweenDates
    {
        
        SqliteContext _context;

        public List<H1ModelDb> GetHistory(DateTime startDate, DateTime EndDate)
        {
            using(var context = new SqliteContext()) 
            {
                var result = context.FoxH1.Where(x => x.LoggedDateTime > startDate && x.LoggedDateTime < EndDate).ToList();
                return result;
            }
        }

    }
}