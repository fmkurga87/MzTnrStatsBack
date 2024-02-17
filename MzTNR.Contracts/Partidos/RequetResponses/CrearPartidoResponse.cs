using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class CrearPartidoResponse : BaseResponse
    {
        public int Id { get; set; }
    }
}