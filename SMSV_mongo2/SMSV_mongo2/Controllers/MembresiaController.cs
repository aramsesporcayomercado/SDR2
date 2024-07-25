using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembresiaController:Controller
    {
        private readonly IMembresiasService _membresiasService;
        public MembresiaController(IMembresiasService membresiasService)
        {

            _membresiasService = membresiasService;
        }

        // GET: api/Alertas
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var membresias = await _membresiasService.GetMembresiasAsync();
            return Ok(membresias);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> GetOne(string codigo)
        {
            var membresias = await _membresiasService.GetById(codigo);
            if (membresias == null)
            {
                return NotFound();
            }
            return Ok(membresias);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Membresias membresia)
        {
            await _membresiasService.CreateASync(membresia);
            return Ok("created sucessfully");
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(string codigo, [FromBody] Membresias Newmembresia)
        {
            var membresia = _membresiasService.GetById(codigo);
            if (membresia == null)
            {
                return NotFound();
            }
            await _membresiasService.Update(codigo, Newmembresia);
            return Ok("update sucessfully");
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(string codigo)
        {
            var membresia = await _membresiasService.GetById(codigo);
            if (membresia == null)
            {
                return NotFound();
            }
            await _membresiasService.Delete(codigo);
            return Ok("Deleted sucessfully");
        }


    }
}
