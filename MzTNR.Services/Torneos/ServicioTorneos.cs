using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Torneos;
using MzTNR.Contracts.Torneos.RequestResponses;

namespace MzTNR.Services.Torneos
{
    public class ServicioTorneos : IServicioTorneos
    {
        public Task<BuscarTorneosResponse> BuscarTorneos(BuscarTorneosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CrearTorneoResponse> CrearTorneo(CrearTorneoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarTorneoResponse> ModificarTorneo(ModificarTorneoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerTorneoResponse> ObtenerTorneo(ObtenerTorneoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}