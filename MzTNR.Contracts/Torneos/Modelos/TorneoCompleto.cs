using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class TorneoCompleto : ResumenTorneo 
    {
        //TODO: Generar los contratos para LA y Copa, luego reemplazar los "string?" por esos modelos.
        //      En el servicio, llenar uno u el otro segun el tipo de torneo que es.
        public List<PosicionLigaAmistosa> DatosLA { get; set; }
        public string? DatosCopa { get; set; }
    }
}