using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Data.Models.TNR
{
    public class Provincia
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Ciudad>? Ciudades { get; set; }
    }
}