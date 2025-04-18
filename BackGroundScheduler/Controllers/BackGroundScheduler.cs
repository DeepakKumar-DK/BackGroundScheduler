using BackGroundScheduler.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace BackGroundScheduler.Controllers
{
    public class BackGroundScheduler:Controller
    {
        private IEmailService _emailservice;
        private IBackgroundJobClient _backgroundjobclient;
        private IRecurringJobManager _recurringJobManager;

        public BackGroundScheduler(IEmailService emailservice, IBackgroundJobClient backgroundjobclient, IRecurringJobManager recurringJobManager)
        {
            _emailservice = emailservice;
            _backgroundjobclient = backgroundjobclient;
            _recurringJobManager = recurringJobManager;
        }
        [HttpGet]
        [Route("Scheduler")]
        public ActionResult createAlert()
        {
            // Executes Immediately;
            var jobId = BackgroundJob.Enqueue(() => _emailservice.SendEmail("Alert Job", DateTime.Now.ToLongTimeString()));
            BackgroundJob.Enqueue(jobId, () => Console.WriteLine($"Email sent Succesffully with Id {jobId}"));
            return Ok($"Background Job  Running with Id {jobId}");

            //Recurring job for scheduling 
            //RecurringJob.AddOrUpdate(() => _emailservice.SendEmail("Alert Job", DateTime.Now.ToLongTimeString()),Cron.Daily(21,42));
            //return Ok($"Background Job Executed 3:12 Am daily");
        }

    }
}
