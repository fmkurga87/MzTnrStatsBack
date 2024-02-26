using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Partidos.RequetResponses;
using MzTNR.Contracts.Provincias.RequestResponses;

namespace MzTNR.Contracts.Provincias
{
    public interface IServicioProvincias
    {
        Task<BuscarProvinciasResponse> BuscarProvincias(BuscarProvinciasRequest request);
        Task<CrearProvinciaResponse> CrearProvincia(CrearProvinciaRequest request);
        Task<ModificarProvinciaResponse> ModificarProvincia(ModificarProvinciaRequest request);
        Task<ObtenerProvinciaResponse> ObtenerProvincia(ObtenerProvinciaRequest request);
    }
}