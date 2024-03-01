using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class BuscarTorneosRequest : BusquedaPaginadaRequest
    {
        public int? IdMz { get; set; }
        public string? Nombre { get; set; }
        public int? Edicion { get; set; }
        public int? TemporadaMZ { get; set; }
        public int? IdEquipo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}