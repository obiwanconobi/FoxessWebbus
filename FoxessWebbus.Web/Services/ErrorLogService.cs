using FoxessWebbus.Web.Data;

namespace FoxessWebbus.Web.Services
{
    public class ErrorLogService
    {

        public async void LogError(string Message, string Method)
        {
            SqliteContext context = new SqliteContext();

            var errorModel = new ErrorLog()
            {
                ErrorLogId = Guid.NewGuid(),
                Message = Message,
                Method = Method,
                ErrorDateTime = DateTime.Now,
            };

            context.ErrorLog.Add(errorModel);
            await context.SaveChangesAsync();
        }

    }
}
