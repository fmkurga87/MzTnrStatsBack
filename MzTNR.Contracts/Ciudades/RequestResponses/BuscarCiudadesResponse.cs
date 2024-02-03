using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Ciudades.DTOs;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Ciudades.RequestResponses
{
    public class BuscarCiudadResponse : BusquedaPaginadaResponse<CiudadDTO>
    {
        public BuscarCiudadResponse(BuscarCiudadesRequest request) : base(request) { }
    }
}