using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Partidos.Modelos;

namespace MzTNR.Contracts.Partidos.RequetResponses
{
    public class BuscarHistorialResponse : BaseResponse
    {
        public int TotalPartidos { get; set; }
        public string? Equipo1 { get; set; }
        public int GanadosEquipo1 { get; set; }
        public int Empatados { get; set; }
        public string? Equipo2 { get; set; }
        public int GanadosEquipo2 { get; set; }
        public List<ResumenPartido> Partidos { get; set; }
    }
}