using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Ciudades.Modelos
{
    public class ResumenCiudad
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public string? Provincia { get; set; }
    }
}