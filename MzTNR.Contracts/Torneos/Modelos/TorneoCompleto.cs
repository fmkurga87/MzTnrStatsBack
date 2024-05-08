using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class TorneoCompleto : ResumenTorneo 
    {
        public List<PosicionLigaAmistosa>? DatosLA { get; set; }
        public Copa? DatosCopa { get; set; }
    }
}