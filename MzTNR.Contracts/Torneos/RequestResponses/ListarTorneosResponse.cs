using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Torneos.DTOs;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class ListarTorneosResponse
    {
        public List<TorneoListaDTO> TorneosPorTemporada { get; set; }
    }
}