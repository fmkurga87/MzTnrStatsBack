using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Equipos.RequestResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;

namespace MzTNR.Services.Equipos
{
    public class ServicioEquipos : IServicioEquipos
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public ServicioEquipos(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        
        public Task<BuscarEquiposResponse> BuscarEquipos(BuscarEquiposRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CrearEquipoResponse> CrearEquipo(CrearEquipoRequest request)
        {
            var equipoNuevo = _mapper.Map<Equipo>(request);
            _applicationDbContext.Equipos.Add(equipoNuevo);
            var id = await _applicationDbContext.SaveChangesAsync();
            
            return new CrearEquipoResponse() { Id = id };
        }

        public Task<ModificarEquipoResponse> ModificarEquipo(ModificarEquipoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerEquipoResponse> ObtenerEquipo(ObtenerEquipoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}