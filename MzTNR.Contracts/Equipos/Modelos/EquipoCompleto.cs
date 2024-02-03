using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Equipos.DTOs;

namespace MzTNR.Contracts.Equipos.Modelos
{
    public class EquipoCompleto : ResumenEquipo
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        
        //TODO: Mostrar solo los nombres
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }

        //TODO: Armar la URL por codigo
        public string? UrlEscudo { get; set; }

        //TODO: Agregar lista de ultimos partidos y proximos partidos
    }
}