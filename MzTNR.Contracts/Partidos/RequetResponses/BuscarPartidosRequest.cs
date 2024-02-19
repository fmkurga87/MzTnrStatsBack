using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class BuscarPartidosRequest : BusquedaPaginadaRequest
    {
        public int? idEquipo { get; set; }
        public int? idTorneo { get; set; }
    }
}