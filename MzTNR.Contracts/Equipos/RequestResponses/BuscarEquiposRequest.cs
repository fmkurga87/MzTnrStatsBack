using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Contracts.Equipos.RequestResponses
{
    public class BuscarEquiposRequest : BusquedaPaginadaRequest
    {
        public string? Nombre { get; set; }
        public string? UsuarioMZ { get; set; }
        public int? CiudadId { get; set; }
    }
}