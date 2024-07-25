using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorSignosController : Controller
    {
        private readonly IMonitorSignosService _monitorSignosService;
        public MonitorSignosController(IMonitorSignosService monitorSignosService)
        {

            _monitorSignosService = monitorSignosService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var monitor = await _monitorSignosService.GetMonitorAsync();
            return Ok(monitor);
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetOne(int codigo)
        {
            var monitor = await _monitorSignosService.GetById(codigo);
            if (monitor == null)
            {
                return NotFound();
            }
            return Ok(monitor);
        }
        [HttpPost]
        public async Task<IActionResult> Post(MonitorSignos monitorSignos)
        {
            await _monitorSignosService.CreateASync(monitorSignos);
            return Ok("The monitor was created successfully");
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, [FromBody] MonitorSignos NewMonitor)
        {
            var monitor = _monitorSignosService.GetById(codigo);
            if (monitor == null)
            {
                return NotFound();
            }
            await _monitorSignosService.Update(codigo, NewMonitor);
            return Ok("The Monitor was updated successfully");
        }
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            var monitor = await _monitorSignosService.GetById(codigo);
            if (monitor == null)
            {
                return NotFound();
            }
            await _monitorSignosService.Delete(codigo);
            return Ok("The monitor was deleted successfully");
        }
    }
}
