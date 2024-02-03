using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Compartidos
{
    public abstract class BusquedaPaginadaRequest
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public BusquedaPaginadaRequest()
        {
            this.NumeroPagina = 1;
            this.CantidadPagina = 10;
            this.DireccionOrdenamiento = EnumDireccionOrdenamientoGenerico.SinEspecificar;
        }

        /// <summary>
        /// Número de página a buscar.
        /// </summary>
        public int NumeroPagina { get; set; }

        /// <summary>
        /// Cantidad de elementos por página.
        /// </summary>
        [Range(0, 500, ErrorMessage = "El valor máximo de página es de 500 elementos.")]
        public int CantidadPagina { get; set; }


        /// <summary>
        /// Nombre de la entidad para ordenar el resultado. 
        /// Se debe usar el método nameof() con una propiedad de la entidad que devuelve el método.
        /// Aquellas propiedades que permitan ordenamiento, lo tendrán indicado en su info.
        /// </summary>
        public string EntidadOrdenamiento { get; set; } 

        /// <summary>
        /// Dirección de ordenamiento.
        /// Si se selecciona una entidad, también debe estar indicada una dirección para ordenar, de lo contrario, no ordenará.
        /// </summary>
        public EnumDireccionOrdenamientoGenerico DireccionOrdenamiento { get; set; }
    }
}