using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Partidos.Modelos;

namespace MzTNR.Contracts.Partidos
{
    public interface IServicioPartidos
    {
        /// <summary>
        /// Obtener lista de partidos desde el XML de MZ
        /// </summary>
        /// <param name="idEquipo"></param>
        /// <param name="tipoPartidos"></param>
        /// <returns></returns>
        Task<List<ResumenPartido>> ObtenerPartidosXML(int idEquipo, int tipoPartidos);
    }
}