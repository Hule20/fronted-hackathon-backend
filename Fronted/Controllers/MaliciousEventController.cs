using Fronted.Data;
using Fronted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Fronted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaliciousEventController : ControllerBase
    {
        private readonly DataContext _context;

        public MaliciousEventController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/[controller]/GetAll")]
        public ActionResult GetAll()
        {
            var result = _context.MaliciousEvents.ToList();
            return Ok(result);
        }

        [HttpGet("/[controller]/Get/{id}")]
        public ActionResult GetSingle(int id)
        {
            var result = _context.MaliciousEvents.Find(id);
            if (result == null)
            {
                return NotFound("Event does not exist");
            }

            return Ok(result);
        }

        [HttpPost("/[controller]/Add")]
        public ActionResult<List<MaliciousEvent>> Add(MaliciousEvent maliciousEvent)
        {
            _context.MaliciousEvents.Add(maliciousEvent);
            _context.SaveChanges();

            var result = _context.MaliciousEvents;
            return Ok(result);
        }

        [HttpPut("/[controller]/Update/{id}")]
        public ActionResult<MaliciousEvent> Update(int id, MaliciousEvent newInfo)
        {
            var result = _context.MaliciousEvents.Find(id);

            if (result == null)
            {
                return NotFound("Event does not exist");
            }

            //TODO
            //result.ThreatLevel = newInfo.ThreatLevel;
            //result.ThreatType = newInfo.ThreatType;
            _context.SaveChanges();

            return Ok(result);
        }

        [HttpDelete("/[controller]/Delete/{id}")]
        public ActionResult<List<MaliciousEvent>> Delete(int id)
        {
            var result = _context.MaliciousEvents.Find(id);
            if (result == null)
            {
                return NotFound("Event does not exist");
            }
            _context.SaveChanges();

            return Ok(result);
        }
    }
}
