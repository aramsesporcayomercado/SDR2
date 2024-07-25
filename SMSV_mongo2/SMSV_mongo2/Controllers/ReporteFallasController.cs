using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteFallasController : Controller
    {
        private readonly IReporteFallasService _reporteFallasService;
        public ReporteFallasController(IReporteFallasService reporteFallasService)
        {

            _reporteFallasService = reporteFallasService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var reporte = await _reporteFallasService.GetAllAsyc();
            return Ok(reporte);
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetOne(int codigo)
        {
            var reporte = await _reporteFallasService.GetById(codigo);
            if (reporte == null)
            {
                return NotFound();
            }
            return Ok(reporte);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ReporteFallas reporte)
        {
            await _reporteFallasService.CreatAsync(reporte);
            return Ok("The report was created successfully");
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, [FromBody] ReporteFallas NewReporte)
        {
            var cliente = _reporteFallasService.GetById(codigo);
            if (cliente == null)
            {
                return NotFound();
            }
            await _reporteFallasService.Update(codigo,NewReporte );
            return Ok("The report was updated successfully");
        }
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            var reporte = await _reporteFallasService.GetById(codigo);
            if (reporte == null)
            {
                return NotFound();
            }
            await _reporteFallasService.DeleteAsync(codigo);
            return Ok("The report was deleted successfully");
        }
    }
}
