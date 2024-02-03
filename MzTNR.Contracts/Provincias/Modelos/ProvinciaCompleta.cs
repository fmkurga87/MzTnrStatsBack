using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Ciudades.RequestResponses;
using MzTNR.Contracts.Provincias.DTOs;

namespace MzTNR.Contracts.Provincias.Modelos
{
    public class ProvinciaCompleta : ProvinciaDTO
    {
        public BuscarCiudadResponse? Ciudades { get; set; }
    }
}