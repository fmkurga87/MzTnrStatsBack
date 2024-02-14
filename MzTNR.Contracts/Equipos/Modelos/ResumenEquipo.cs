using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Equipos.Modelos
{
    public class ResumenEquipo
    {
        public int? IdMz { get; set; }
        public string? NombreEquipo { get; set; }
        public string? UsuarioMZ { get; set; }
    }
}