using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Data.Models.TNR
{
    public class Torneo
    {
        public int Tipo { get; set; }
        public int IdMz { get; set; }
        public string? Nombre { get; set; }
        public int Edicion { get; set; }
        public int TemporadaMZ { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Link { get; set; }
        public int? IdCampeon { get; set; }
        public string? UrlImagen { get; set; }
        
        // Relaciones uno a uno
        public LigaAmistosa? LigasAmistosas { get; set; }
        public FaseGrupo? FasesGrupos { get; set; }
        public Imagen? Imagen { get; set;}

        // Uno a Muchos
        public ICollection<Playoff>? Playoffs { get; set; }
        public ICollection<Partido>? Partidos { get; set; }
    }
}