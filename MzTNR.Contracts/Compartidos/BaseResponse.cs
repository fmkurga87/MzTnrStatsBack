using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Compartidos
{
    public abstract class BaseResponse
    {

        public BaseResponse()
        {
            Errores = new List<Tuple<string, string>>();
        }       

        public ICollection<Tuple<string, string>> Errores { get; set; }

        public void AddError(string key, string value)
        {
            Errores.Add(new Tuple<string, string>(key, value));
        }
    }

    public abstract class BaseResponseWithFound : BaseResponse
    {
        /// <summary>
        /// Indica si se encontró el elemento
        /// </summary>
        public bool Encontrado { get; set; }
    }
}