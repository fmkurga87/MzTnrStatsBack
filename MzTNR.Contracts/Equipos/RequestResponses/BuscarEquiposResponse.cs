using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Equipos.DTOs;
using MzTNR.Contracts.Equipos.Modelos;

namespace MzTNR.Contracts.Equipos.RequestResponses
{
    public class BuscarEquiposResponse : BusquedaPaginadaResponse<ResumenEquipo>
    {
        public BuscarEquiposResponse(BuscarEquiposRequest request) : base(request) { }
    }
}