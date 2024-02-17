using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class ModificarTorneoRequest : CrearTorneoRequest
    {
        public int Id { get; set; }
    }
}