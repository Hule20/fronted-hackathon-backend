using Fronted.Data;
using Fronted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fronted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompleteReportController : ControllerBase
    {
        private readonly DataContext _context;

        public CompleteReportController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/[controller]/GetAll")]
        public ActionResult GetAll()
        {
            var result = _context.MaliciousEvents
                                    .FromSql($"SELECT maliciousEvents.id AS id, urlVisited, visitedAt, originIp, ipv4Address, macAddress,\r\n           pulseCount, malwareCount, threatType, platformTypes.name AS platformName\r\n    FROM MaliciousEvents\r\n        JOIN devices ON maliciousEvents.deviceId = devices.id\r\n        JOIN assessmentReports ON maliciousEvents.assessmentReportId = assessmentReports.id\r\n        JOIN platformTypes ON assessmentReports.platformTypeId = platformTypes.id;")
                                    .ToList();

            return Ok(result);
        }

    }
}
