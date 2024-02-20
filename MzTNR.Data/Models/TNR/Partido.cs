using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Data.Models.TNR
{
    public class Partido
    {
        public int Id { get; set; }
        public int IdMz { get; set; }
        public virtual Equipo? EquipoLocal { get; set; }
        public int? EquipoLocalId { get; set; }  
        public int GolesLocal { get; set; }
        public virtual Equipo? EquipoVisitante { get; set; }
        public int? EquipoVisitanteId { get; set; }  
        public int GolesVisitante { get; set; }
        public DateTime? Fecha { get; set; }
        // Fecha 1, Fecha 2...
        public int FechaNumero { get; set; }

        public virtual Torneo? Torneo { get; set; }
        public int? TorneoId { get; set; }
    }
}