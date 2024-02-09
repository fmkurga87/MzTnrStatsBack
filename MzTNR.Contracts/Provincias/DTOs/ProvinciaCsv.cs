using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Provincias.DTOs
{
    public class ProvinciaCsv
    {
        /*
        "categoria","centroide_lat","centroide_lon","fuente","id","iso_id","iso_nombre","nombre","nombre_completo"
"Ciudad Autónoma",-34.6144420654301,-58.4458763250916,"IGN","02","AR-C","Ciudad Autónoma de Buenos Aires","Ciudad Autónoma de Buenos Aires","Ciudad Autónoma de Buenos Aires"
"Provincia",-38.6419828626673,-70.1198972237318,"IGN","58","AR-Q","Neuquén","Neuquén","Provincia del Neuquén"
*/
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