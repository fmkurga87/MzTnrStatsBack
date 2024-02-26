using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class CargarResultadoRequest
    {
        public int IdPartido { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
    }
}