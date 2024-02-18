using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Ciudades;
using MzTNR.Contracts.Ciudades.DTOs;
using MzTNR.Contracts.Ciudades.Modelos;
using MzTNR.Contracts.Ciudades.RequestResponses;
using MzTNR.Contracts.Equipos.Modelos;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;
using MzTNR.Services.Extensiones;
using MzTNR.Services.Profiles;

namespace MzTNR.Services.Ciudades
{
    public class ServicioCiudades : IServicioCiudades
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        
        public ServicioCiudades(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
            
        }
        public async Task<BuscarCiudadResponse> BuscarCiudades(BuscarCiudadesRequest request)
        {
            var ciudades = _applicationDbContext.Ciudades.Where(ObtenerPredicadoCiudades(request)).Paginate(request);

            return new BuscarCiudadResponse(request){ Elementos = _mapper.Map<List<CiudadDTO>>(ciudades)};
        }

        public async Task<CrearCiudadResponse> CrearCiudad(CrearCiudadRequest request)
        {
            var ciudadNueva = _mapper.Map<Ciudad>(request);
            _applicationDbContext.Ciudades.Add(ciudadNueva);
            var id = await _applicationDbContext.SaveChangesAsync();
            
            return new CrearCiudadResponse() { Id = id };
        }

        public async Task<ModificarCiudadResponse> ModificarCiudad(ModificarCiudadRequest request)
        {
            ModificarCiudadResponse response = new ModificarCiudadResponse();

            var ciudadAModificar = await _applicationDbContext.Ciudades.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (ciudadAModificar != null)
            {
                ciudadAModificar.Nombre = request.Nombre;
                ciudadAModificar.ProvinciaId = request.ProvinciaId;
                ciudadAModificar.CoordenadaX = request.CoordenadaX;
                ciudadAModificar.CoordenadaY = request.CoordenadaY;

                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                response.AddError("Ciudad", $"No se encontro la ciudad con id: {request.Id}");
            }

            return response;
        }

        public async Task<ObtenerCiudadResponse> ObtenerCiudad(ObtenerCiudadRequest request)
        {
            ObtenerCiudadResponse response = new ObtenerCiudadResponse() { Encontrado = true };
            
            var ciudad = await _applicationDbContext.Ciudades.FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if (ciudad == null)
            {
                response.AddError("Ciudad", $"No se encontro la ciudad con id: {request.Id}");
                response.Encontrado = false;
            }
            else
            {
                CiudadCompleta ciudadCompleta = new CiudadCompleta() 
                {
                    Id = ciudad.Id,
                    Nombre = ciudad.Nombre,
                    CoordenadaX = ciudad.CoordenadaX,
                    CoordenadaY = ciudad.CoordenadaY,
                    ProvinciaId = ciudad.ProvinciaId,
                    Equipos = _mapper.Map<List<ResumenEquipo>>(_applicationDbContext.Equipos.Where(x => x.CiudadId == request.Id ))
                };
                
                response.Ciudad = ciudadCompleta;
            }
 
            return response;
        }


        private static Expression<Func<Ciudad, bool>> ObtenerPredicadoCiudades(BuscarCiudadesRequest request)
        {
            var predicado = PredicateBuilder.New<Ciudad>();

            if (!String.IsNullOrEmpty(request.Nombre))
            {
                predicado.And(x => x.Nombre.Contains(request.Nombre));
            }
            
            if (request.ProvinciaId.HasValue && request.ProvinciaId.Value != 0)
            {
                predicado.And(x => x.ProvinciaId == request.ProvinciaId.Value);
            }

            return predicado;
        }
    }
}