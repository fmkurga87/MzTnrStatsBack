using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Ciudades.RequestResponses
{
    public class CrearCiudadRequest
    {
        public string? Nombre { get; set; }
        public string? CoordenadaX { get; set; }
        public string? CoordenadaY { get; set; }
        public int? ProvinciaId { get; set; }
    }
}