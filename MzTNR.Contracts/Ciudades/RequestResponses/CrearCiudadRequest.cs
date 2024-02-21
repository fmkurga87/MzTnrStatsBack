using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Ciudades.RequestResponses
{
    public class CrearCiudadRequest
    {
        [Required]
        public string? Nombre { get; set; }
        public string? CoordenadaX { get; set; }
        public string? CoordenadaY { get; set; }
        [Required]
        public int? ProvinciaId { get; set; }
    }
}