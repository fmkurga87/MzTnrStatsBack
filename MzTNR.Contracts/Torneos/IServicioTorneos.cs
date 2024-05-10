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
        Task<CrearGrupoCopaResponse> CrearGrupoCopa(CrearGrupoCopaRequest request);
        Task<ModificarTorneoResponse> ModificarTorneo(ModificarTorneoRequest request);
        Task<ObtenerTorneoResponse> ObtenerTorneo(ObtenerTorneoRequest request);
        Task<CargarUrlImagenResponse> CargarUrlImagen(CargarUrlImagenRequest request);
        Task<BuscarTorneosResponse> BuscarTorneosMock(int cant);
        Task<ListarTorneosResponse> ListarTorneos();
        Task<ListarTorneosResponse> ListarTorneosPorEquipo(int IdMzEquipo);

        // TODO: Agregar metodo para recalcular posiciones de la copa.
    }
}