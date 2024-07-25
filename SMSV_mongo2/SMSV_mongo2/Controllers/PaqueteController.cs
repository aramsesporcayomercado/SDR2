using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : Controller
    {
        private readonly IPaquetesService _paquetesService;
        public PaqueteController(IPaquetesService paqueteService)
        {

            _paquetesService = paqueteService;
        }

        // GET: api/Alertas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var paquete = await _paquetesService.GetPaquetesAsync();
            return Ok(paquete);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetOne(string codigo)
        {
            var paquete = await _paquetesService.GetById(codigo);
            if (paquete == null)
            {
                return NotFound();
            }
            return Ok(paquete);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Paquetes paquete)
        {
            await _paquetesService.CreateASync(paquete);
            return Ok("created sucessfully");
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(string codigo, [FromBody] Paquetes Newpaquete)
        {
            var paquete = _paquetesService.GetById(codigo);
            if (paquete == null)
            {
                return NotFound();
            }
            await _paquetesService.Update(codigo, Newpaquete);
            return Ok("update sucessfully");
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(string codigo)
        {
            var paquete = await _paquetesService.GetById(codigo);
            if (paquete == null)
            {
                return NotFound();
            }
            await _paquetesService.Delete(codigo);
            return Ok("Deleted sucessfully");
        }
    }
}
