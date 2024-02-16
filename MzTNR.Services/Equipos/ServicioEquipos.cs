using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Equipos.DTOs;
using MzTNR.Contracts.Equipos.Modelos;
using MzTNR.Contracts.Equipos.RequestResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;
using MzTNR.Services.Extensiones;

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
        
        public async Task<BuscarEquiposResponse> BuscarEquipos(BuscarEquiposRequest request)
        {
            var equipos = _applicationDbContext.Equipos.Where(ObtenerPredicadoEquipos(request)).Paginate(request);

            return new BuscarEquiposResponse(request){ Elementos = _mapper.Map<List<ResumenEquipo>>(equipos)};
        }

        public async Task<CrearEquipoResponse> CrearEquipo(CrearEquipoRequest request)
        {
            var equipoNuevo = _mapper.Map<Equipo>(request);
            _applicationDbContext.Equipos.Add(equipoNuevo);
            var id = await _applicationDbContext.SaveChangesAsync();
            
            return new CrearEquipoResponse() { Id = id };
        }

        public async Task<ModificarEquipoResponse> ModificarEquipo(ModificarEquipoRequest request)
        {
            ModificarEquipoResponse response = new ModificarEquipoResponse();

            var equipoAModificar = await _applicationDbContext.Equipos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (equipoAModificar != null)
            {
                equipoAModificar.NombreEquipo = request.NombreEquipo;
                equipoAModificar.UsuarioMZ = request.UsuarioMZ;
                equipoAModificar.Nombre = request.Nombre;
                equipoAModificar.Apellido = request.Apellido;
                equipoAModificar.CiudadId = request.CiudadId;


                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                response.AddError("Equipo", $"No se encontro el Equipo con id: {request.Id}");
            }

            return response;
        }

        public async Task<ObtenerEquipoResponse> ObtenerEquipo(ObtenerEquipoRequest request)
        {
            ObtenerEquipoResponse obtenerEquipoResponse = new ObtenerEquipoResponse() { Encontrado = true};

            var equipo = await _applicationDbContext.Equipos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (equipo != null)
            {
                EquipoCompleto datosEquipo = new EquipoCompleto() 
                {
                    IdMz = equipo.IdMz,
                    NombreEquipo = equipo.NombreEquipo,
                    UsuarioMZ = equipo.UsuarioMZ,
                    Nombre = equipo.Nombre,
                    Apellido = equipo.Apellido,
                    
                    //TODO: Mostrar solo los nombres (usar ResumenCiudad -> Agregar mapeo)
                    //Ciudad =
                    //Provincia = 
                  
                    UrlEscudo = $"https://www.managerzone.com/dynimg/badge.php?team_id={equipo.IdMz}&sport=soccer",
                    // TODO: Agregar una fx que reciba id de equipo MZ y si se consultan partidos jugados o proximos, y se obtnega el xml
                    //PartidosJugados = 
                    //PartidosProximos = 
                };
                obtenerEquipoResponse.Equipo = datosEquipo;
                
            }
            else
            {
                obtenerEquipoResponse.Encontrado = false;
                obtenerEquipoResponse.AddError("Equipo", $"No se encontro el Equipo con id: {request.Id}");
            }

            return obtenerEquipoResponse;
        }

        private static Expression<Func<Equipo, bool>> ObtenerPredicadoEquipos(BuscarEquiposRequest request)
        {
            var predicado = PredicateBuilder.New<Equipo>();

            if (!String.IsNullOrEmpty(request.Nombre))
            {
                predicado.And(x => x.Nombre.Contains(request.Nombre));
            }

            if (!String.IsNullOrEmpty(request.UsuarioMZ))
            {
                predicado.And(x => x.UsuarioMZ.Contains(request.UsuarioMZ));
            }
            
            if (request.CiudadId.HasValue && request.CiudadId.Value != 0)
            {
                predicado.And(x => x.CiudadId == request.CiudadId.Value);
            }

            return predicado;
        }
    }
}