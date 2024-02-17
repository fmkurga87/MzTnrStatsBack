using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class CrearTorneoRequest
    {
        public int IdMz { get; set; }
        public string? Nombre { get; set; }
        public int Edicion { get; set; }
        public int TemporadaMZ { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Link { get; set; }
        public EnumTipoTorneo Tipo { get; set; }
    }
}