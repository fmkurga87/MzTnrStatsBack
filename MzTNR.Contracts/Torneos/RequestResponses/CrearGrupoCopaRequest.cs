using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Torneos.Modelos;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class CrearGrupoCopaRequest : GrupoCopa
    {
        public int TorneoId { get; set; } 
    }
}