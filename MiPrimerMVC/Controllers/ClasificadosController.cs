using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimerMVC.Models;

namespace MiPrimerMVC.Controllers
{
    
    public class ClasificadosController : Controller
    {
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
	}
}