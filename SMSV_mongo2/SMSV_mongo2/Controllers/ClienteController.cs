using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClientesService _clienteService;
        public ClienteController(IClientesService clienteService)
        {

            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }
        [HttpGet("{numero}")]
        public async Task<IActionResult> GetOne(int numero)
        {
            var clientes = await _clienteService.GetById(numero);
            if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Clientes cliente)
        {
            await _clienteService.CreateASync(cliente);
            return Ok("The client was created successfully");
        }

        [HttpPut("{numero}")]
        public async Task<IActionResult> Put(int numero, [FromBody] Clientes Newcliente)
        {
            var cliente = _clienteService.GetById(numero);
            if (cliente == null)
            {
                return NotFound();
            }
            await _clienteService.Update(numero, Newcliente);
            return Ok("The client was updated successfully");
        }
        [HttpDelete("{numero}")]
        public async Task<IActionResult> Delete(int numero)
        {
            var cliente = await _clienteService.GetById(numero);
            if (cliente == null)
            {
                return NotFound();
            }
            await _clienteService.Delete(numero);
            return Ok("The client was deleted successfully");
        }
    }
}
