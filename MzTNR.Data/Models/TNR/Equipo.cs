using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Data.Models.TNR
{
    public class Equipo
    {
        public int Id { get; set; }
        public string? NombreEquipo { get; set; }
        public string? UsuarioMZ { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public bool Borrado { get; set; }

        public virtual Ciudad? Ciudad { get; set; }
        public int? CiudadId { get; set; }       

        // Ojo en realidad es uno a uno
        public ICollection<LigaAmistosa>? LigasAmistosas { get; set; }

    }
}