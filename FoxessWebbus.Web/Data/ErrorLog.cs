namespace FoxessWebbus.Web.Data
{
    public class ErrorLog
    {
        public Guid ErrorLogId { get; set; }
        public string Message { get; set; }
        public string Method { get; set; }
        public DateTime ErrorDateTime { get; set; } 
    }
}
