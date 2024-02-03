using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Compartidos
{
    /// <summary>
    /// Respuesta de una consulta paginada.
    /// </summary>
    /// <typeparam name="T">Entidad de contrato.</typeparam>
    public abstract class BusquedaPaginadaResponse<T> where T : class, new()
    {
        /// <summary>
        /// Cantidad página.
        /// </summary>
        private readonly int cantidadPagina; 

        /// <summary>
        /// Constructor vacío. Solamente está disponible para que la documentación
        /// pueda armar del response de la API.
        /// </summary>
        protected BusquedaPaginadaResponse() { }

        /// <summary>
        /// Constructor de la respuesta.
        /// </summary>
        /// <param name="request">Request de la búsqueda paginada.</param>
        protected BusquedaPaginadaResponse(BusquedaPaginadaRequest request)
        {
            if (request != null)
            {
                this.cantidadPagina = request.CantidadPagina;
                this.NumeroPagina = request.NumeroPagina;
            }
        }

        /// <summary>
        /// Número de página.
        /// </summary>
        public int NumeroPagina { get; set; }

        /// <summary>
        /// Cantidad de elementos en la página.
        /// </summary>
        public int CantidadPagina
        {
            get
            {
                if (this.cantidadPagina > this.CantidadTotal)
                {
                    return this.CantidadTotal;
                }

                return this.cantidadPagina;
            }
        }

        /// <summary>
        /// Cantidad total de elementos resultantes de la búsqueda.
        /// </summary>
        public int CantidadTotal { get; set; }

        /// <summary>
        /// Elementos resultantes.
        /// </summary>
        public IList<T> Elementos { get; set; }
    }
}