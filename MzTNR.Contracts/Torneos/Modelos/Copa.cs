using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class Copa
    {
        public List<GrupoCopa> Grupos { get; set; }
        public List<EliminatoriasCopa> Playoff { get; set; }
    }
}