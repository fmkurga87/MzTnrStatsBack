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

        public int Grupo { get; set; }
        public int Posicion { get; set; }

        public virtual Equipo? Equipo { get; set; }
        public int? EquipoId { get; set; }  

        // Se calcula
        //public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosEmpatados { get; set; }
        public int PartidosPerdidos { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }

        // Se Calcula
        //public int DiferenciaGol { get; set; }
        // Se Calcula
        //public int Puntos { get; set; }
    }
}