using Fronted.Data;
using Fronted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fronted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public PlatformTypeController(DataContext context)
        {
            _context = context;
        }

        //ThreatTypes
        [HttpGet("/[controller]/GetAll")]
        public ActionResult GetAll()
        {
            var result = _context.PlatformTypes.ToList();
            return Ok(result);
        }

        [HttpGet("/[controller]/GetAll/{id}")]
        public ActionResult GetSingle(int id)
        {
            var result = _context.PlatformTypes.Find(id);
            if (result == null)
            {
                return NotFound("This threat does not exist");
            }

            return Ok(result);
        }

        [HttpPost("/[controller]/Add")]
        public ActionResult<List<PlatformType>> Add(PlatformType threat)
        {
            _context.PlatformTypes.Add(threat);
            _context.SaveChanges();

            var result = _context.PlatformTypes;
            return Ok(result);
        }

        [HttpPut("/[controller]/Update/{id}")]
        public ActionResult<PlatformType> Update(int id, PlatformType newInfo)
        {
            var result = _context.PlatformTypes.Find(id);

            if (result == null)
            {
                return NotFound("This threat does not exist");
            }

            result.Name = newInfo.Name;
            _context.SaveChanges();

            return Ok(result);
        }

        [HttpDelete("/[controller]/Delete/{id}")]
        public ActionResult<List<PlatformType>> Delete(int id)
        {
            var result = _context.PlatformTypes.Find(id);
            if (result == null)
            {
                return NotFound("This threat does not exist");
            }
            _context.SaveChanges();

            return Ok(result);
        }
    }
}
