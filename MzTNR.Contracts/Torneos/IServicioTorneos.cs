using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Torneos.RequestResponses;

namespace MzTNR.Contracts.Torneos
{
    public interface IServicioTorneos
    {
        Task<BuscarTorneosResponse> BuscarTorneos(BuscarTorneosRequest request);
        Task<CrearTorneoResponse> CrearTorneo(CrearTorneoRequest request);
        Task<ModificarTorneoResponse> ModificarTorneo(ModificarTorneoRequest request);
        Task<ObtenerTorneoResponse> ObtenerTorneo(ObtenerTorneoRequest request);
    }
}