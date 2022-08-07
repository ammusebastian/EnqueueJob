using EnqueueJob.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EnqueueJob.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly ILogger<JobController> _logger;
        public JobController(IJobService jobService, IBackgroundJobClient backgroundJobClient, ILogger<JobController> logger)
        {
            _jobService = jobService;
            _backgroundJobClient = backgroundJobClient;
            _logger = logger;
        }

        [HttpPost("/SortArray")]
        public ActionResult SortArray([System.Web.Http.FromUri]int[] iList)
        {
            _logger.LogInformation($"Starting at {DateTime.UtcNow.TimeOfDay}");
            _backgroundJobClient.Enqueue(() => _jobService.SortArray(iList));
            _logger.LogInformation($"Ended at {DateTime.UtcNow.TimeOfDay}");
            return Ok();
        }
    }
}
