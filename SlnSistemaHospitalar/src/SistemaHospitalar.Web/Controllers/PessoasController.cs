using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Models;

namespace SistemaHospitalar.Web.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }


        // GET: PessoasController
        public ActionResult Index()
        {
            var pessoa = _service.GetAll();
            return View(pessoa);
        }

        // GET: PessoasController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _service.FindById(id);
            return View(pessoa);
        }

        // GET: PessoasController/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        // POST: PessoasController/Create
        [HttpPost]
        public async Task<IActionResult> Create(PessoaDTO pessoa)
        {
            var retDel = new ReturnJson
            {
                status = "Success",
                code = "200"
            };

            pessoa.createdOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                //await _service.Save(pessoa);
                if(await _service.Save(pessoa) <= 0)
                {
                    retDel = new ReturnJson
                    {
                        status = "Error",
                        code = "400"
                    };
                }
                
            }

            return PartialView("Create", "Pacientes");
        }

        public async Task<PartialViewResult> Edit(int id)
        {

            var pessoa = await _service.FindById(id);
            return PartialView(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PessoaDTO pessoa)
        {
            if (id == null || pessoa == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _service.Save(pessoa);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso";
                return RedirectToAction("Edit", "Pacientes");
            }

            TempData["MensagemErro"] = "Erro ao alterar registro";
            return RedirectToAction("Edit", "Pacientes");

        }

        // GET: PessoasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoasController/Delete/5
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
