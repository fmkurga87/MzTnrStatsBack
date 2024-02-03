using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Equipos.RequestResponses;

namespace MzTNR.Services.Equipos
{
    public class ServicioEquipos : IServicioEquipos
    {
        public Task<BuscarEquiposResponse> BuscarEquipos(BuscarEquiposRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CrearEquipoResponse> CrearEquipo(CrearEquipoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarEquipoResponse> ModificarEquipo(ModificarEquipoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerEquipoResponse> ObtenerEquipo(ObtenerEquipoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}