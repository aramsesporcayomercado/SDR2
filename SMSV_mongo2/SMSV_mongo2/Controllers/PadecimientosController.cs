using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    public class PadecimientosController : Controller
    {
        private readonly IPadecimientosService _padecimientosService;
        public PadecimientosController(IPadecimientosService padecimientosService)
        {

            _padecimientosService = padecimientosService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var padecimientoss = await _padecimientosService.GetMonitorAsync();
            return Ok(padecimientoss);
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetOne(int codigo)
        {
            var padecimientoss = await _padecimientosService.GetById(codigo);
            if (padecimientoss == null)
            {
                return NotFound();
            }
            return Ok(padecimientoss);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Padecimientos padecimientos)
        {
            await _padecimientosService.CreateASync(padecimientos);
            return Ok("The padecimientos was created successfully");
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, [FromBody] Padecimientos Newpadecimientos)
        {
            var padecimientos = _padecimientosService.GetById(codigo);
            if (padecimientos == null)
            {
                return NotFound();
            }
            await _padecimientosService.Update(codigo, Newpadecimientos);
            return Ok("The padecimientos was updated successfully");
        }
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            var padecimientos = await _padecimientosService.GetById(codigo);
            if (padecimientos == null)
            {
                return NotFound();
            }
            await _padecimientosService.Delete(codigo);
            return Ok("The padecimientos was deleted successfully");
        }
    }
}
