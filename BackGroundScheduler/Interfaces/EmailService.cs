namespace BackGroundScheduler.Interfaces
{
    public class EmailService : IEmailService
    {
        public string SendEmail(string jobType, string starttime)
        {
            Console.Write(jobType + "-" + starttime + "- Email Successfully Sent -" + DateTime.Now.ToLongTimeString());
            var id = Guid.NewGuid();
            return id.ToString();
        }
    }
}
