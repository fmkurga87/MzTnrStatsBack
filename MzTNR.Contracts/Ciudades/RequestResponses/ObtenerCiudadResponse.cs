using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Ciudades.DTOs;
using MzTNR.Contracts.Ciudades.Modelos;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Ciudades.RequestResponses
{
    public class ObtenerCiudadResponse : BaseResponseWithFound
    {
        public CiudadCompleta? Ciudad { get; set; }
    }
}