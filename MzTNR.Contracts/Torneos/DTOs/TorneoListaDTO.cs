using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.DTOs
{
    public class TorneoListaDTO
    {
        public int IdMz { get; set; }
        public string? Nombre { get; set; }
        public int Edicion { get; set; }
        public int TemporadaMZ { get; set; }
        public bool EnCurso { get; set; }
    }
}