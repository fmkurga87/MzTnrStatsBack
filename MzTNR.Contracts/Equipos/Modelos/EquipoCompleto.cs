using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Equipos.DTOs;
using MzTNR.Contracts.Partidos.Modelos;

namespace MzTNR.Contracts.Equipos.Modelos
{
    public class EquipoCompleto : ResumenEquipo
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Ciudad { get; set; }
        public string? Provincia { get; set; }
        public string? UrlEscudo { get; set; }
        public List<ResumenPartido> PartidosJugados { get; set; }
        public List<ResumenPartido> PartidosProximos { get; set; }

    }
}