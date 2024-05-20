using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class CrearPartidoRequest
    {
        [Required]
        public int IdMz { get; set; }
        public int? EquipoLocalId { get; set; }  
        public int GolesLocal { get; set; }
        public int? EquipoVisitanteId { get; set; }  
        public int GolesVisitante { get; set; }
        public string? Link { get; set; }
        public DateTime? Fecha { get; set; }
        // Fecha 1, Fecha 2...
        public int FechaNumero { get; set; }
        public int? TorneoId { get; set; }
        public int? TipoPartido { get; set; }
        public EnumInstanciaPartido? Instancia { get; set; }
    }
}