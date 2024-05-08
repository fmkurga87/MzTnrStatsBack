using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Partidos.Modelos;

namespace MzTNR.Contracts.Torneos.Modelos
{
    public class EliminatoriasCopa
    {
        public EnumInstanciaPartido Instancia { get; set; }
        public List<ResumenPartido> Partidos { get; set; }
    }
}