using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Partidos.DTOs;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class BuscarPartidosResponse : BusquedaPaginadaResponse<PartidoDTO>
    {
        public BuscarPartidosResponse(BuscarPartidosRequest request) : base(request) { }
    }
}