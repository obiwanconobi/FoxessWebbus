using FoxessWebbus.Web.Data;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FoxessWebbus.Web.Services
{
    public class ErrorLogService
    {

        public async Task<List<ErrorLog>> GetErrors()
        {
            SqliteContext context = new SqliteContext();

            var errors = context.ErrorLog.OrderByDescending(x => x.ErrorDateTime).Take(100).ToList();
            return errors;
        }

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
