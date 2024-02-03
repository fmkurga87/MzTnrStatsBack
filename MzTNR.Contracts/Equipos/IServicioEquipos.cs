using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Equipos.RequestResponses;

namespace MzTNR.Contracts.Equipos
{
    public interface IServicioEquipos
    {
        Task<BuscarEquiposResponse> BuscarEquipos(BuscarEquiposRequest request);
        Task<CrearEquipoResponse> CrearEquipo(CrearEquipoRequest request);
        Task<ModificarEquipoResponse> ModificarEquipo(ModificarEquipoRequest request);
        Task<ObtenerEquipoResponse> ObtenerEquipo(ObtenerEquipoRequest request);
    }
}