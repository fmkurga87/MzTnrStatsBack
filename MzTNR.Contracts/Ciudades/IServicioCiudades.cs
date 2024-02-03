using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Ciudades.RequestResponses;

namespace MzTNR.Contracts.Ciudades
{
    public interface IServicioCiudades
    {
        Task<BuscarCiudadResponse> BuscarCiudades(BuscarCiudadesRequest request);
        Task<CrearCiudadResponse> CrearCiudad(CrearCiudadRequest request);
        Task<ModificarCiudadResponse> ModificarCiudad(ModificarCiudadRequest request);
        Task<ObtenerCiudadResponse> ObtenerCiudad(ObtenerCiudadRequest request);
    }
}