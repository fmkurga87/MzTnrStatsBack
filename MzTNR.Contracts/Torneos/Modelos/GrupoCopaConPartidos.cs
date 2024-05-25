using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Partidos.Modelos;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class GrupoCopaConPartidos : GrupoCopa
    {
        public List<ResumenPartido> PartidosDelGrupo { get; set; }
    }
}