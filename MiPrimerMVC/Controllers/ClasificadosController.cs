using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerMVC.Controllers
{
    [Authorize]
    public class ClasificadosController : Controller
    {
        //
        // GET: /Clasificados/
        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }
	}
}