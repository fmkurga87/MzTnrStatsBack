using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Provincias.DTOs;

namespace MzTNR.Contracts.Provincias.RequestResponses
{
    public class BuscarProvinciasResponse : BusquedaPaginadaResponse<ProvinciaDTO>
    {
        public BuscarProvinciasResponse(BuscarProvinciasRequest request) : base(request) { }
    }
}