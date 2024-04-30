using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class BuscarHistorialRequest
    {
        public int IdEquipo1 { get; set; }
        public int IdEquipo2 { get; set; }
    }
}