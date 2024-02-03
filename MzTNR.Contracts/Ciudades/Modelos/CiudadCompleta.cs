using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Ciudades.DTOs;
using MzTNR.Contracts.Equipos.DTOs;
using MzTNR.Contracts.Equipos.Modelos;

namespace MzTNR.Contracts.Ciudades.Modelos
{
    public class CiudadCompleta : CiudadDTO
    {
        public List<ResumenEquipo>? Equipos { get; set; }
    }
}