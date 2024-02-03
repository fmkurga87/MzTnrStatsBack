using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Equipos.Modelos;

namespace MzTNR.Contracts.Equipos.RequestResponses
{
    public class ObtenerEquipoResponse : BaseResponseWithFound
    {
        public EquipoCompleto? Equipo { get; set; }
    }
}