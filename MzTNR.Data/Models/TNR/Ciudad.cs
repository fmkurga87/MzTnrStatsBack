using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Data.Models.TNR
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CoordenadaX { get; set; }
        public string? CoordenadaY { get; set; }
        public bool Borrado { get; set; }

        public virtual Provincia? Provincia { get; set; }
        public int? ProvinciaId { get; set; }

        public ICollection<Equipo>? Equipos { get; set; }

    }
}