using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Provincias.RequestResponses
{
    public class ModificarProvinciaRequest : CrearProvinciaRequest
    {
        public int Id { get; set; }
    }
}