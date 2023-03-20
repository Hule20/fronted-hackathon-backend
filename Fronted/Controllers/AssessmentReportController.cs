using Fronted.Data;
using Fronted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fronted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentReportController : ControllerBase
    {
        private readonly DataContext _context;

        public AssessmentReportController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/[controller]/GetAll")]
        public ActionResult GetAll()
        {
            var result = _context.AssessmentReports.ToList();
            return Ok(result);
        }

        [HttpGet("/[controller]/Get/{id}")]
        public ActionResult GetSingle(int id)
        {
            var result = _context.AssessmentReports.Find(id);
            if (result == null)
            {
                return NotFound("Report does not exist");
            }

            return Ok(result);
        }

        [HttpPost("/[controller]/Add")]
        public ActionResult<List<AssessmentReport>> Add(AssessmentReport device)
        {
            _context.AssessmentReports.Add(device);
            _context.SaveChanges();

            var result = _context.AssessmentReports;
            return Ok(result);
        }

        [HttpPut("/[controller]/Update/{id}")]
        public ActionResult<AssessmentReport> Update(int id, AssessmentReport newInfo)
        {
            var result = _context.AssessmentReports.Find(id);

            if (result == null)
            {
                return NotFound("Report does not exist");
            }
            //TODO 
            _context.SaveChanges();

            return Ok(result);
        }

        [HttpDelete("/[controller]/Delete/{id}")]
        public ActionResult<List<AssessmentReport>> Delete(int id)
        {
            var result = _context.AssessmentReports.Find(id);

            if (result == null)
            {
                return NotFound("Device does not exist");
            }
            _context.AssessmentReports.Remove(result);
            _context.SaveChanges();

            return Ok(_context.AssessmentReports);
        }
    }
}
