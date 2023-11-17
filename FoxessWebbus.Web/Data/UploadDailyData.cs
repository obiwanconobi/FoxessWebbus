using FoxessWebbus.Web.Services;

namespace FoxessWebbus.Web.Data
{

    public class UploadDailyData
    {

        private SqliteContext? _context;
        private ErrorLogService? _errorLogger;

        public async void UploadData(H1DailyModel model)
        {
            _context ??= new SqliteContext();
            using (var context = new SqliteContext())
            {

                try
                {
                    context.DailyH1.Add(model);
                    await context.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    _errorLogger = new ErrorLogService();

                    _errorLogger.LogError(ex.ToString(), "DAILY UPLOAD");
                    Console.WriteLine(ex.ToString());
                }



            }

            


        }
    }
}
