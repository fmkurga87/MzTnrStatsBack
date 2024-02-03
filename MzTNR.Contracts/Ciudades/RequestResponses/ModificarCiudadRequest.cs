using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Ciudades.RequestResponses
{
    public class ModificarCiudadRequest : CrearCiudadRequest
    {
        public int Id { get; set; }
    }
}