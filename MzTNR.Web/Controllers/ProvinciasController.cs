using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MzTNR.Contracts.Provincias;
using MzTNR.Contracts.Provincias.RequestResponses;

namespace MzTNR.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        public IServicioProvincias _servicioProvincias { get; }
        public IMapper _mapper { get; }
        private readonly ILogger<ProvinciasController> _logger;

        public ProvinciasController(IServicioProvincias servicioProvincias, IMapper mapper, ILogger<ProvinciasController> logger )
        {
            _servicioProvincias = servicioProvincias;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Route("Provincia")]
        public async Task<ActionResult> Post([FromBody] CrearProvinciaRequest crearProvinciaRequest)
        {
            // TODO: Validar request
            var crearProvinciaResponse = await _servicioProvincias.CrearProvincia(crearProvinciaRequest);

            return Ok(crearProvinciaResponse);
        }

        [HttpGet]
        [Route("Provincia/{Id}")]
        public async Task<ActionResult> Get([FromRoute] ObtenerProvinciaRequest obtenerProvinciaRequest)
        {
            var obtenerProvinciaResponse = await _servicioProvincias.ObtenerProvincia(obtenerProvinciaRequest);

            return Ok(obtenerProvinciaResponse);
        }

        [HttpGet]
        [Route("Provincia")]
        public async Task<ActionResult> Get([FromQuery] BuscarProvinciasRequest buscarProvinciaRequest)
        {
            var obtenerProvinciaResponse = await _servicioProvincias.BuscarProvincias(buscarProvinciaRequest);

            return Ok(obtenerProvinciaResponse);
        }
    }
}