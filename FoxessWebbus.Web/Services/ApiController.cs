using FoxessWebbus.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoxessWebbus.Web.Services
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {

        [HttpGet("GetLatest")]
        public H1Model GetLatest()
        {
            GetLatestDataService service = new GetLatestDataService();
            return service.GetData();
        }

        [HttpGet("GetDaily")]
        public List<H1DailyModel> GetDaily()
        {
            GetDailyStatisticsService service = new GetDailyStatisticsService();
            return service.GetData();
        }


    }
}
