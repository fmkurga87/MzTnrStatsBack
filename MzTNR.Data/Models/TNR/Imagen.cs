using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Data.Models.TNR
{
    public class Imagen
    {
        public int Id { get; set; } 
        public string? Url { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        
        public Torneo? Torneo { get; set; }
        public int TorneoId { get; set; }
    }
}