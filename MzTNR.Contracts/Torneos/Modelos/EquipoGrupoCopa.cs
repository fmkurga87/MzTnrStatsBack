using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class EquipoGrupoCopa
    {
        public int? TorneoId { get; set; } 
        public int? EquipoId { get; set; }  
        public string? EquipoNombre { get; set; }
        public int? Posicion { get; set; }
        public int? Puntos { get; set; }
        public int? PartidosJugados { get; set; }
        public int? PartidosGanados { get; set; }
        public int? PartidosEmpatados { get; set; }
        public int? PartidosPerdidos { get; set; }
        public int? GolesAFavor { get; set; }
        public int? GolesEnContra { get; set; }
        public int? DiferenciaGol { get; set; }
        
    }
}