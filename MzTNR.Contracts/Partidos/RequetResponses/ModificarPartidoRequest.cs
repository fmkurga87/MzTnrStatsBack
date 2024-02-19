using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class ModificarPartidoRequest : CrearPartidoRequest
    {
        public int Id { get; set; }
    }
}