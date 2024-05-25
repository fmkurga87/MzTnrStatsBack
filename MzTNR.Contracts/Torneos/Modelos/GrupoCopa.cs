using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Partidos.Modelos;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class GrupoCopa
    {
        public string Grupo { get; set; }
        public List<EquipoGrupoCopa> EquiposGrupo { get; set; }
        public List<ResumenPartido> PartidosDelGrupo { get; set; }
    }
}