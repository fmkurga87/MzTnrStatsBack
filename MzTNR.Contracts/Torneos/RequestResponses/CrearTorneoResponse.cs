using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class CrearTorneoResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}