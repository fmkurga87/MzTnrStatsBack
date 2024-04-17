using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Partidos.Modelos
{
    public class ResumenPartido
    {

        // TODO: Ver que atributos agregar, podria ser el tipo de competencia (LA, Amistoso, etc) + el nombre de la competencia. 
        // Para el tipo se podria agregar un enum
        public EnumTipoPartidoEng TipoPartido { get; set; }
        public bool EsTNR { get; set; }
        public int? IdTorneo { get; set; }
        public string? NombreTorneo { get; set; }
        public string? EquipoLocal { get; set; }  
        public int GolesLocal { get; set; }
        public string? EquipoVisitante { get; set; }
        public int GolesVisitante { get; set; }
    }
}