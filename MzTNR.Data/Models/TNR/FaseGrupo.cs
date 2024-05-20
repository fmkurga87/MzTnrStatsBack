using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Data.Models.TNR
{
    public class FaseGrupo
    {
        public int Id { get; set; }

        public virtual Torneo? Torneo { get; set; }
        public int? TorneoId { get; set; } 

        public string? Grupo { get; set; }
        public virtual Equipo? Equipo { get; set; }
        public int? EquipoId { get; set; }  
    }
}