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
        public ActionResult IndexCards(int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 4; // parámetro
            var lista = db.det_sede_carrera.GroupBy(x => x.id_carrera).Select(grp => grp.FirstOrDefault()).OrderBy(x => x.tb_carreras.nom_carrera).Skip((pagina - 1) * cantidadRegistrosPorPagina).Take(cantidadRegistrosPorPagina).ToList();

            var totalDeRegistros = db.det_sede_carrera.GroupBy(x => x.id_carrera).Select(grp => grp.FirstOrDefault()).Count();


            var modelo = new BaseModelo();
            modelo.listaDetallesSedeCarrera = lista;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            ViewBag.totalDeRegistros = totalDeRegistros;
            return View(modelo);

        }


        public PartialViewResult Paginador(int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 4;
            var lista = from p in db.det_sede_carrera
                        select p;
            var totalDeRegistros = lista.GroupBy(x => x.id_carrera).Select(grp => grp.FirstOrDefault()).Count();
            ViewBag.totalDeRegistros = totalDeRegistros;
            var modelo = new BaseModelo();
            modelo.listaDetallesSedeCarrera = lista.ToList();
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            return PartialView(modelo);
        }
    }
}