using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Equipos.DTOs
{
    public class EquipoDTO
    {
        public int Id { get; set; }
        public string? NombreEquipo { get; set; }
        public string? UsuarioMZ { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

    }
}