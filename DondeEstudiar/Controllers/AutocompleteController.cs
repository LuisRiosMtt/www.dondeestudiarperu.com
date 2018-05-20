using DondeEstudiar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DondeEstudiar.Entidades;
namespace DondeEstudiar.Controllers
{
    public class AutocompleteController : Controller
    {
        bd_dondeestudiarEntities db = new bd_dondeestudiarEntities();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCarrera(string search) {

            List<CarrerasModel> carreras =
                db.tb_carreras.Where(x =>
                x.nom_carrera.Contains(search))
                .Select(x => new CarrerasModel
                {
                    id_carrera = x.id_carrera,
                    nom_carrera = x.nom_carrera
                }).Take(5).ToList();
            return new JsonResult { Data = carreras, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetArea(string search)
        {

            List<AreasModel> areas =
                db.tb_areas.Where(x =>
                x.desc_area.Contains(search))
                .Select(x => new AreasModel
                {
                    id_area = x.id_area,
                    desc_area = x.desc_area
                }).Take(5).ToList();
            return new JsonResult { Data = areas, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult getInstitucion(string search)
        {

            List<InstitucionesModel> instituciones =
                db.tb_instituciones.Where(x =>
                x.nom_institucion.Contains(search))
                .Select(x => new InstitucionesModel
                {
                    id_institucion = x.id_institucion,
                    nom_institucion = x.nom_institucion
                }).Take(5).ToList();
            return new JsonResult { Data = instituciones, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetUbigeo(string search)
        {


            List<UbigeoModel> ubigeos =
                db.tb_ubigueos.Where(x =>
                x.desc_dep.StartsWith(search))
                .Select(x => new UbigeoModel 
                {
                    cod_dep = x.cod_dep,
                    desc_dep = x.desc_dep,
                    
                }).GroupBy(x => x.desc_dep).Select(grp => grp.FirstOrDefault()).ToList();
            return new JsonResult { Data = ubigeos, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetPOPCarrera(string searchTerm) {
            var ListaCarrera = db.tb_carreras.Take(5).ToList();

            if (searchTerm != null) {
                ListaCarrera = db.tb_carreras.Where(x =>
                x.nom_carrera.Contains(searchTerm)).Take(5).ToList();
            }

            var modifiedData = ListaCarrera.Select(x => new {
                id = x.nom_carrera,
                text = x.nom_carrera
            });

            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPOPInstitucion(string searchTerm)
        {
            var ListaInsti = db.tb_instituciones.Take(5).ToList();

            if (searchTerm != null)
            {
                ListaInsti = db.tb_instituciones.Where(x =>
                x.nom_institucion.Contains(searchTerm)).Take(5).ToList();
            }

            var modifiedData = ListaInsti.Select(x => new {
                id = x.nom_institucion,
                text = x.nom_institucion
            });

            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPOPUbicacion(string searchTerm)
        {
            var ListaUbicacion = db.tb_ubigueos.GroupBy(x => x.desc_dep).Select(grp => grp.FirstOrDefault()).Take(10).ToList();

            if (searchTerm != null)
            {
                ListaUbicacion = db.tb_ubigueos.Where(x =>
                x.desc_dep.Contains(searchTerm)).GroupBy(x => x.desc_dep).Select(grp => grp.FirstOrDefault()).Take(10).ToList();
            }

            var modifiedData = ListaUbicacion.Select(x => new {
                id = x.desc_dep,
                text = x.desc_dep
            });

            return Json(modifiedData, JsonRequestBehavior.AllowGet);
        }


    }
}