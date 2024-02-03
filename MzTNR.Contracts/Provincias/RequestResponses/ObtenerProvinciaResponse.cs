using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Provincias.Modelos;

namespace MzTNR.Contracts.Provincias.RequestResponses
{
    public class ObtenerProvinciaResponse : BaseResponseWithFound
    {
        public ProvinciaCompleta? Provincia { get; set; }
    }
}