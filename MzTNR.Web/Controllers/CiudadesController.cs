using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MzTNR.Contracts.Ciudades;
using MzTNR.Contracts.Ciudades.RequestResponses;
using MzTNR.Data.Data;

namespace MzTNR.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        public IServicioCiudades _servicioCiudades { get; }
        public IMapper _mapper { get; }
        private readonly ILogger<CiudadesController> _logger;

        public CiudadesController(IServicioCiudades servicioCiudades, IMapper mapper, ILogger<CiudadesController> logger )
        {
            _servicioCiudades = servicioCiudades;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearCiudadRequest crearCiudadRequest)
        {
            // TODO: Validar request
            var crearCiudadResponse = await _servicioCiudades.CrearCiudad(crearCiudadRequest);

            return Ok(crearCiudadResponse);
        }
    
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ModificarCiudadRequest modificarCiudadRequest)
        {
            // TODO: Validar request
            var modificarCiudadResponse = await _servicioCiudades.ModificarCiudad(modificarCiudadRequest);

            return Ok(modificarCiudadResponse);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> Get([FromRoute] ObtenerCiudadRequest obtenerCiudadRequest)
        {
            var obtenerCiudadResponse = await _servicioCiudades.ObtenerCiudad(obtenerCiudadRequest);

            return Ok(obtenerCiudadResponse);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] BuscarCiudadesRequest buscarCiudadRequest)
        {
            var obtenerCiudadResponse = await _servicioCiudades.BuscarCiudades(buscarCiudadRequest);

            return Ok(obtenerCiudadResponse);
        }
    }
}