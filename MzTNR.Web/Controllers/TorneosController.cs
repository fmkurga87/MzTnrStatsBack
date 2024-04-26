using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MzTNR.Contracts.Torneos;
using MzTNR.Contracts.Torneos.RequestResponses;
using MzTNR.Data.Models.TNR;

namespace MzTNR.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneosController : ControllerBase
    {
        public IServicioTorneos _servicioTorneos { get; }
        public IMapper _mapper { get; }
        private readonly ILogger<TorneosController> _logger;

        public TorneosController(IServicioTorneos servicioTorneos, IMapper mapper, ILogger<TorneosController> logger )
        {
            _servicioTorneos = servicioTorneos;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearTorneoRequest crearTorneoRequest)
        {
            // TODO: Validar request
            var crearTorneoResponse = await _servicioTorneos.CrearTorneo(crearTorneoRequest);

            return Ok(crearTorneoResponse);
        }
    
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ModificarTorneoRequest modificarTorneoRequest)
        {
            // TODO: Validar request
            var modificarTorneoResponse = await _servicioTorneos.ModificarTorneo(modificarTorneoRequest);

            return Ok(modificarTorneoResponse);
        }

        [HttpPut]
        [Route("/api/Imagen")]
        public async Task<ActionResult> Put([FromBody] CargarUrlImagenRequest cargarUrlImagenRequest)
        {
            var cargarUrlImagenResponse = await _servicioTorneos.CargarUrlImagen(cargarUrlImagenRequest);

            return Ok(cargarUrlImagenResponse);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> Get([FromRoute] ObtenerTorneoRequest obtenerTorneoRequest)
        {
            var obtenerTorneoResponse = await _servicioTorneos.ObtenerTorneo(obtenerTorneoRequest);

            return Ok(obtenerTorneoResponse);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] BuscarTorneosRequest buscarTorneosRequest)
        {
            var obtenerTorneoResponse = await _servicioTorneos.BuscarTorneos(buscarTorneosRequest);

            return Ok(obtenerTorneoResponse);
        }

        [HttpGet]
        [Route("Mock/{cant}")]
        public async Task<ActionResult> Get([FromRoute] int cant)
        {
            var obtenerTorneoResponse = await _servicioTorneos.BuscarTorneosMock(cant);

            return Ok(obtenerTorneoResponse);
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Get()
        {
            var listaTorneos = await _servicioTorneos.ListarTorneos();

            return Ok(listaTorneos);
        }

        [HttpGet]
        [Route("Lista/{idEquipo}")]
        public async Task<ActionResult> GetTorneos([FromRoute] int idEquipo)
        {
            var listaTorneos = await _servicioTorneos.ListarTorneosPorEquipo(idEquipo);

            return Ok(listaTorneos);
        }
    }
}