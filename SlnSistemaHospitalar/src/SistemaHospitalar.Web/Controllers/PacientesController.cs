using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;

namespace SistemaHospitalar.Web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteService _service;
        private readonly IConvenioService _convenioService;
        private readonly IPessoaService _pessoaService;

        public PacientesController(IPacienteService service, IConvenioService convenioService, IPessoaService pessoaService)
        {
            _service = service;
            _convenioService = convenioService;
            _pessoaService = pessoaService;
        }


        // GET: PacientesController
        public ActionResult Index()
        {
            var Paciente = _service.GetAll();
            return View(Paciente);
        }

        // GET: PacientesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _service.FindById(id);
            return View(paciente);
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            ViewData["pessoaId"] = new SelectList(_pessoaService.GetAll(), "id", "nome", "Selecione...");
            ViewData["convenioId"] = new SelectList(_convenioService.GetAll(), "id", "nome", "Selecione...");
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PacienteDTO paciente)
        {
            var pessoa = _pessoaService.GetAll().Last();
                if (ModelState.IsValid)
                {
                    paciente.pessoaId = pessoa.id;
                    await _service.Save(paciente);
                    TempData["MensagemSucesso"] = "Registro adicionado com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                ViewData["pessoaId"] = new SelectList(_pessoaService.GetAll(), "id", "nome", "Selecione...");
                ViewData["convenioId"] = new SelectList(_convenioService.GetAll(), "id", "nome", "Selecione...");
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paciente = await _service.FindById(id);
            //ViewData["pessoaId"] = new SelectList(_pessoaService.GetAll(), "id", "nome", "Selecione...");
            ViewData["convenioId"] = new SelectList(_convenioService.GetAll(), "id", "nome", "Selecione...");
            return View(Paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PacienteDTO paciente)
        {
            if (id == null || paciente == null)
            {
                return NotFound();
            }

            //var pessoa = await _pessoaService.FindById(paciente.pessoa.id);
            //aciente.pessoaId = pessoa.id;
            if (ModelState.IsValid)
            {
                await _service.Save(paciente);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            //ViewData["pessoaId"] = new SelectList(_pessoaService.GetAll(), "id", "nome", "Selecione...");
            ViewData["convenioId"] = new SelectList(_convenioService.GetAll(), "id", "nome", "Selecione...");
            TempData["MensagemErro"] = "Erro ao alterar registro";
            return RedirectToAction(nameof(Index));

        }

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
