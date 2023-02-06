using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Infra.Data.Context;

namespace SistemaHospitalar.Web.Controllers
{
    public class ConveniosController : Controller
    {
        private readonly IConvenioService _service;

        public ConveniosController(IConvenioService service)
        {
            _service = service;
        }


        // GET: ConveniosController
        public ActionResult Index()
        {
            var conv = _service.GetAll();
            return View(conv);
        }

        // GET: ConveniosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var conv = await _service.FindById(id);
            return View(conv);
        }

        // GET: ConveniosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConveniosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ConvenioDTO convenio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Save(convenio);
                    TempData["MensagemSucesso"] = "Convênio adicionado com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["MensagemErro"] = "Erro ao adicionar covênio";
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var conv = await _service.FindById(id);
            return View(conv);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ConvenioDTO convenio)
        {
            if(id == null || convenio == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.Save(convenio);
                TempData["MensagemSucesso"] = "Convênio alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }

            TempData["MensagemErro"] = "Erro ao alterar covênio";
            return RedirectToAction(nameof(Index));
    
        }

        // GET: ConveniosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConveniosController/Delete/5
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
