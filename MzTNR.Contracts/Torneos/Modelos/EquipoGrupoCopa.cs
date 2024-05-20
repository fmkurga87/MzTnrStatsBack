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
        
    }
}