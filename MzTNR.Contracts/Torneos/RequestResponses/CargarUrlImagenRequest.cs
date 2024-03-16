using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Torneos.RequestResponses
{
    public class CargarUrlImagenRequest
    {
        public int IdTorneo{ get; set; }
        public string UrlImagen { get; set; }
    }
}