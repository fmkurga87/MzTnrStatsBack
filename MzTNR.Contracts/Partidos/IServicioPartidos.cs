using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Partidos.Modelos;
using MzTNR.Contracts.Partidos.RequetResponses;

namespace MzTNR.Contracts.Partidos
{
    public interface IServicioPartidos
    {
        Task<BuscarPartidosResponse> BuscarPartidos(BuscarPartidosRequest request);
        Task<CrearPartidoResponse> CrearPartido(CrearPartidoRequest request);
        Task<ModificarPartidoResponse> ModificarPartido(ModificarPartidoRequest request);
        Task<ObtenerPartidoResponse> ObtenerPartido(ObtenerPartidoRequest request);
        /// <summary>
        /// Obtener lista de partidos desde el XML de MZ
        /// </summary>
        /// <param name="idEquipo"></param>
        /// <param name="tipoPartidos"></param>
        /// <returns></returns>
        Task<List<ResumenPartido>> ObtenerPartidosXML(int idEquipo, int tipoPartidos);
        Task<CargarResultadoResponse> CargarResultado(CargarResultadoRequest request);
        Task<BuscarHistorialResponse> BuscarHistorial(BuscarHistorialRequest request);
    }
}