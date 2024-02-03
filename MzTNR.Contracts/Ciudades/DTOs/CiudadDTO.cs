using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Ciudades.DTOs
{
    public class CiudadDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CoordenadaX { get; set; }
        public string? CoordenadaY { get; set; }
        public int? ProvinciaId { get; set; }
    }
}