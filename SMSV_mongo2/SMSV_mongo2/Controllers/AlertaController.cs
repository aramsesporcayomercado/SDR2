using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertasService _alertasService;
        public AlertaController(IAlertasService alertasService) {

            _alertasService = alertasService;
        }

        // GET: api/Alertas
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var alertas = await _alertasService.GetAlertasAsync();
            return Ok(alertas);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult> GetOne(string codigo)
        {
            var alertas = await _alertasService.GetById(codigo);
            if (alertas == null)
            {
                return NotFound();
            }
            return Ok(alertas);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Alertas alertas)
        {
            await _alertasService.CreateASync(alertas);
            return Ok("created sucessfully");
        }
        
        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(string codigo, [FromBody] Alertas Newalerta)
        {
            var alerta = _alertasService.GetById(codigo);
            if (alerta == null)
            {
                return NotFound();
            }
            await _alertasService.Update(codigo,Newalerta);
            return Ok("update sucessfully");
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(string codigo)
        {
            var alerta = await _alertasService.GetById(codigo);
                if(alerta == null)
            {
                return NotFound();
            }
            await _alertasService.Delete(codigo);
            return Ok("Deleted sucessfully");
        }


    }
}
