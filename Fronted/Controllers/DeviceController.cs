using Fronted.Data;
using Fronted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fronted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DataContext _context;

        public DeviceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/[controller]/GetAll")]
        public ActionResult GetAll()
        {
            var result = _context.Devices.ToList();
            return Ok(result);
        }

        [HttpGet("/[controller]/Get/{id}")]
        public ActionResult GetSingle(int id)
        {
            var result = _context.Devices.Find(id);
            if (result == null)
            {
                return NotFound("Event does not exist");
            }

            return Ok(result);
        }

        [HttpPost("/[controller]/Add")]
        public ActionResult<List<Device>> Add(Device device)
        {
            _context.Devices.Add(device);
            _context.SaveChanges();

            var result = _context.Devices;
            return Ok(result);
        }

        [HttpPut("/[controller]/Update/{id}")]
        public ActionResult<Device> Update(int id, Device newInfo)
        {
            var result = _context.Devices.Find(id);

            if (result == null)
            {
                return NotFound("Event does not exist");
            }

            result.Name = newInfo.Name;
            result.OperatingSystem = newInfo.OperatingSystem;
            _context.SaveChanges();

            return Ok(result);
        }

        [HttpDelete("/[controller]/Delete/{id}")]
        public ActionResult<List<Device>> Delete(int id)
        {
            var result = _context.Devices.Find(id);

            if (result == null)
            {
                return NotFound("Device does not exist");
            }
            _context.Devices.Remove(result);
            _context.SaveChanges();

            return Ok(_context.Devices);
        }
    }
}
