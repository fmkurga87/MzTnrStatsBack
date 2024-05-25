using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Equipos.Modelos;


namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class CrearGrupoCopaRequest
    {
        public int TorneoId { get; set; } 
        public string Grupo { get; set;}
        public List<ResumenEquipo> EquiposGrupo { get; set; }
    }
}