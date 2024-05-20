using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class GrupoCopa
    {
        public string Grupo { get; set; }
        public List<EquipoGrupoCopa> EquiposGrupo { get; set; }
    }
}