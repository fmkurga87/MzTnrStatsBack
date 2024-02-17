using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Torneos.DTOs;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class BuscarTorneosResponse : BusquedaPaginadaResponse<TorneoDTO>
    {
        public BuscarTorneosResponse(BuscarTorneosRequest request) : base(request) { }
    }
}