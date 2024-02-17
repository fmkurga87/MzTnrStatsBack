using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Torneos.Modelos;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class ObtenerTorneoResponse : BaseResponseWithFound
    {
        public ResumenTorneo? Torneo { get; set; }
    }
}