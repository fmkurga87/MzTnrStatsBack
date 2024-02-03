using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Ciudades.RequestResponses
{
    public class BuscarCiudadesRequest : BusquedaPaginadaRequest
    {
        public string? Nombre { get; set; }
        public int? ProvinciaId { get; set; }
    }
}