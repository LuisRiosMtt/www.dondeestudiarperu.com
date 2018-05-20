using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DondeEstudiarHost.Controllers;
using DondeEstudiar.Models;

namespace DondeEstudiarHost.Controllers
{
    public class HomeController : Controller
    {
        bd_dondeestudiarEntities db = new bd_dondeestudiarEntities();
        public ActionResult Index()
        {
            var lista = from p in db.det_sede_carrera
                            //where DbFunctions.TruncateTime(p.tb_paquete.fecha_compra) >= DbFunctions.TruncateTime(DateTime.Today)                     
                        select p ;

            return View(lista.ToList());
        }
        public ActionResult FiltroPreguntas(String carrera, String institucion, String ubicacion)
        {
            var lista = db.det_sede_carrera.Where
                (x => x.tb_carreras.nom_carrera.ToLower().Contains(carrera) && x.tb_sedes.tb_instituciones.nom_institucion.ToLower().Contains(institucion) &&
                x.tb_sedes.tb_ubigueos.desc_dep.ToLower().Contains(ubicacion));

            
            //Me trae las variables que filtro
            ViewBag.dtCarrera = carrera;
            ViewBag.dtInstitucion = institucion;
            ViewBag.dtUbicacion = ubicacion;

            return View(lista.ToList());
        }

        public ActionResult FiltroCards(String carrera, String institucion, String ubicacion)
        {
            var lista = db.det_sede_carrera.Where
                (x => x.tb_carreras.nom_carrera.ToLower().Contains(carrera) && x.tb_sedes.tb_instituciones.nom_institucion.ToLower().Contains(institucion) &&
                x.tb_sedes.tb_ubigueos.desc_dep.ToLower().Contains(ubicacion));


            //Me trae las variables que filtro
            ViewBag.dtCarrera = carrera;
            ViewBag.dtInstitucion = institucion;
            ViewBag.dtUbicacion = ubicacion;

            return View(lista.ToList());
        }


        public ActionResult Preguntas() {

            return View();
         }

    }
}