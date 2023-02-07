using Microsoft.AspNetCore.Mvc;
using SistemaHospitalar.Domain.DTO;
using SistemaHospitalar.Domain.IServices;
using SistemaHospitalar.Web.Models;
using SistemaHospitalar.Domain.Entities;

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

            pessoa.createdOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _service.Save(pessoa);
                TempData["MensagemSucesso"] = "Registro cadastrado com sucesso";

                if(pessoa.perfil == PerfilEnum.Medico)
                {
                    return RedirectToAction("Create", "Medicos");
                }

                if (pessoa.perfil == PerfilEnum.Paciente)
                {
                    return RedirectToAction("Create", "Pacientes");
                }

                if (pessoa.perfil == PerfilEnum.Recepcionista)
                {
                    return RedirectToAction("Create", "Recepcionistas");
                }

                if (pessoa.perfil == PerfilEnum.Admin)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            TempData["MensagemSucesso"] = "Erro ao cadastrar registro";
            return View();
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

    }
}
