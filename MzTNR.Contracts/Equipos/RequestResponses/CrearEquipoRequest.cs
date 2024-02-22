using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Equipos.RequestResponses
{
    public class CrearEquipoRequest
    {
        [Required]
        public string? NombreEquipo { get; set; }
        [Required]
        public int? IdMz { get; set; }
        public string? UsuarioMZ { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? CiudadId { get; set; }       
    }
}