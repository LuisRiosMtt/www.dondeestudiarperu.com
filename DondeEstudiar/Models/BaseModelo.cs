using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DondeEstudiar.Models
{
    public class BaseModelo
    {
        public int PaginaActual { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
        //public RouteValueDictionary ValoresQueryString { get; set; }
        public List<Models.det_sede_carrera> listaDetallesSedeCarrera { get; set; }
    }
}