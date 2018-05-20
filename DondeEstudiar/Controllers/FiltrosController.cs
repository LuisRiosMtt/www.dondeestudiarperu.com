using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DondeEstudiar.Controllers
{
    public class FiltrosController : Controller
    {
        // GET: Filtros
        public ActionResult BusquedaBasica()
        {
            return View();
        }
        public ActionResult BusquedaPersonalidada()
        {
            return View();
        }
    }
}