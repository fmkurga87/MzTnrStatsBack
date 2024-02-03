using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Equipos.RequestResponses
{
    public class ModificarEquipoRequest : CrearEquipoRequest
    {
        public int Id { get; set; }
    }
}