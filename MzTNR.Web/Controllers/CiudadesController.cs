using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MzTNR.Contracts.Ciudades;
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
        
    }
}