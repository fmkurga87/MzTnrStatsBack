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
        public string? NombreEquipo { get; set; }
        public int? Posicion { get; set; }
        public int? Puntos { get; set; } = 0;
        public int? PartidosJugados { get; set; } = 0;
        public int? PartidosGanados { get; set; } = 0;
        public int? PartidosEmpatados { get; set; } = 0;
        public int? PartidosPerdidos { get; set; } = 0;
        public int? GolesAFavor { get; set; } = 0;
        public int? GolesEnContra { get; set; } = 0;
        public int? DiferenciaGol { get; set; } = 0;
        
    }
}