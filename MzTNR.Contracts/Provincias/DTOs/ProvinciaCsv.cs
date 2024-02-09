using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Provincias.DTOs
{
    public class ProvinciaCsv
    {
        public string? categoria { get; set; }
        public string? centroide_lat { get; set; }
        public string? centroide_lon { get; set; }
        public string? fuente { get; set; }
        public string? id { get; set; }
        public string? iso_id { get; set; }
        public string? iso_nombre { get; set; }
        public string? nombre { get; set; }
        public string? nombre_completo { get; set; }
    }
}