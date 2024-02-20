using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Equipos.RequestResponses
{
    public class CrearEquipoResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}