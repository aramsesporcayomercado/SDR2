using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly IPacientesService _pacienteService;
        public PacienteController(IPacientesService pacienteService) {

            _pacienteService = pacienteService;
        }

        // GET: api/Alertas
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var pacientes = await _pacienteService.GetPacientesAsync();
            return Ok(pacientes);
        }

        [HttpGet("{numero}")]
        public async Task<IActionResult> GetOne(int numero)
        {
            var pacientes = await _pacienteService.GetById(numero);
            if (pacientes == null)
            {
                return NotFound();
            }
            return Ok(pacientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pacientes paciente)
        {
            await _pacienteService.CreateASync(paciente);
            return Ok("created sucessfully");
        }
        
        [HttpPut("{numero}")]
        public async Task<IActionResult> Put(int numero, [FromBody] Pacientes Newpaciente)
        {
            var paciente = _pacienteService.GetById(numero);
            if (paciente == null)
            {
                return NotFound();
            }
            await _pacienteService.Update(numero,Newpaciente);
            return Ok("update sucessfully");
        }

        [HttpDelete("{numero}")]
        public async Task<IActionResult> Delete(int numero)
        {
            var paciente = await _pacienteService.GetById(numero);
                if(paciente == null)
            {
                return NotFound();
            }
            await _pacienteService.Delete(numero);
            return Ok("Deleted sucessfully");
        }


        // GET: AlertaController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AlertaController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AlertaController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AlertaController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AlertaController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AlertaController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AlertaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
