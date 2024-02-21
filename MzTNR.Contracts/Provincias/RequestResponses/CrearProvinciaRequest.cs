using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Provincias.RequestResponses
{
    public class CrearProvinciaRequest
    {
        [Required]
        public string? Nombre { get; set; }
    }
}