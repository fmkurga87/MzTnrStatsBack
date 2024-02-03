using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Ciudades.RequestResponses
{
    public class CrearCiudadResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}