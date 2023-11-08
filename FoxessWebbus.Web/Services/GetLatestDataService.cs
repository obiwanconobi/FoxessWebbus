using FoxessWebbus.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace FoxessWebbus.Web.Services
{
    public class GetLatestDataService
    {
        SqliteContext _context;

        public H1Model GetData()
        {
            using(var context = new SqliteContext()) 
            {
                var result = context.FoxH1.OrderByDescending(x => x.LoggedDateTime).FirstOrDefault();
                return result;
            }
        }

    }
}
