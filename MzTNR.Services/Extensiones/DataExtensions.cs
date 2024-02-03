using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MzTNR.Contracts.Compartidos;

namespace MzTNR.Services.Extensiones
{
    /// <summary>
    /// Extensiones sobre el acceso a datos.
    /// </summary>
    public static class DataExtensions
    {
        /// <summary>
        /// Método de paginación automática.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad a paginar.</typeparam>
        /// <param name="query">Query de búsqueda.</param>
        /// <param name="request">Request del servicio para paginar.</param>
        /// <returns>Query de búsqueda con paginación.</returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, BusquedaPaginadaRequest request)
        {
            return query.Skip(request.CantidadPagina * (request.NumeroPagina - 1))
                .Take(request.CantidadPagina);
        }

                /// <summary>
        /// Método de paginación automática.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad a paginar.</typeparam>
        /// <param name="query">Query de búsqueda.</param>
        /// <param name="request">Request del servicio para paginar.</param>
        /// <returns>Query de búsqueda con paginación.</returns>
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> query, BusquedaPaginadaRequest request)
        {
            return query.Skip(request.CantidadPagina * (request.NumeroPagina - 1))
                .Take(request.CantidadPagina);
        }
    }
}