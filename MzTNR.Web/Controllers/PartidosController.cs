using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MzTNR.Contracts.Partidos;
using MzTNR.Contracts.Partidos.RequetResponses;

namespace MzTNR.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        public IServicioPartidos _servicioPartidos { get; }
        public IMapper _mapper { get; }
        private readonly ILogger<PartidosController> _logger;

        public PartidosController(IServicioPartidos servicioPartidos, IMapper mapper, ILogger<PartidosController> logger )
        {
            _servicioPartidos = servicioPartidos;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearPartidoRequest crearPartidoRequest)
        {
            // TODO: Validar request
            var crearPartidoResponse = await _servicioPartidos.CrearPartido(crearPartidoRequest);

            return Ok(crearPartidoResponse);
        }
    
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ModificarPartidoRequest modificarPartidoRequest)
        {
            // TODO: Validar request
            var modificarPartidoResponse = await _servicioPartidos.ModificarPartido(modificarPartidoRequest);

            return Ok(modificarPartidoResponse);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> Get([FromRoute] ObtenerPartidoRequest obtenerPartidoRequest)
        {
            var obtenerPartidoResponse = await _servicioPartidos.ObtenerPartido(obtenerPartidoRequest);

            return Ok(obtenerPartidoResponse);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] BuscarPartidosRequest buscarPartidosRequest)
        {
            var obtenerPartidoResponse = await _servicioPartidos.BuscarPartidos(buscarPartidosRequest);

            return Ok(obtenerPartidoResponse);
        }
    }
}