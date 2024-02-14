using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Equipos.RequestResponses;

namespace MzTNR.Web.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        public IServicioEquipos _servicioEquipos { get; }
        public IMapper _mapper { get; }
        private readonly ILogger<EquiposController> _logger;

        public EquiposController(IServicioEquipos servicioEquipos, IMapper mapper, ILogger<EquiposController> logger )
        {
            _servicioEquipos = servicioEquipos;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearEquipoRequest crearEquipoRequest)
        {
            // TODO: Validar request
            var crearEquipoResponse = await _servicioEquipos.CrearEquipo(crearEquipoRequest);

            return Ok(crearEquipoResponse);
        }
    
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ModificarEquipoRequest modificarEquipoRequest)
        {
            // TODO: Validar request
            var modificarEquipoResponse = await _servicioEquipos.ModificarEquipo(modificarEquipoRequest);

            return Ok(modificarEquipoResponse);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> Get([FromRoute] ObtenerEquipoRequest obtenerEquipoRequest)
        {
            var obtenerEquipoResponse = await _servicioEquipos.ObtenerEquipo(obtenerEquipoRequest);

            return Ok(obtenerEquipoResponse);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] BuscarEquiposRequest buscarEquipoRequest)
        {
            var obtenerEquipoResponse = await _servicioEquipos.BuscarEquipos(buscarEquipoRequest);

            return Ok(obtenerEquipoResponse);
        }
    }
}