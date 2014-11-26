using System.Web.Mvc;
using AutoMapper;
using BootstrapMvcSample.Controllers;
using Domain.Entities;
using Domain.Services;
using MiPrimerMVC.Models;

namespace MiPrimerMVC.Controllers
{
    public class ClasificadosController : BootstrapBaseController
    {
        readonly IMappingEngine _mappingEngine;
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public ClasificadosController(IMappingEngine mappingEngine, IReadOnlyRepository readOnlyRepository,
            IWriteOnlyRepository writeOnlyRepository)
        {
            _mappingEngine = mappingEngine;
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
        }

        //
        // GET: /Clasificados/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(new ClasificadosCreateModel());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ClasificadosCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var newClasificado = _mappingEngine.Map<ClasificadosCreateModel, Clasificado>(model);
                var account =
                    _readOnlyRepository.FirstOrDefault<Account>(x => x.Email == HttpContext.User.Identity.Name);
                _writeOnlyRepository.Create(newClasificado);
                account.AddClasificado(newClasificado);
                var accountUpdated = _writeOnlyRepository.Update(account);
                Success("Clasificado was created.");
                return RedirectToAction("Index", "Clasificados");
            }
            return View(model);
        }
    }
}