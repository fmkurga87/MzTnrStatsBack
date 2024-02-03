using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Ciudades;
using MzTNR.Contracts.Ciudades.RequestResponses;
using MzTNR.Contracts.Provincias;
using MzTNR.Contracts.Provincias.DTOs;
using MzTNR.Contracts.Provincias.Modelos;
using MzTNR.Contracts.Provincias.RequestResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;
using MzTNR.Services.Ciudades;
using MzTNR.Services.Extensiones;

namespace MzTNR.Services.Provincias
{
    public class ServicioProvincias : IServicioProvincias
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly IServicioCiudades _servicioCiudades;

        public ServicioProvincias(ApplicationDbContext applicationDbContext, IMapper mapper, IServicioCiudades servicioCiudades)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _servicioCiudades = servicioCiudades;
        }
        
        public async Task<BuscarProvinciasResponse> BuscarProvincias(BuscarProvinciasRequest request)
        {
             var provincias = await _applicationDbContext.Provincias.Where(ObtenerPredicadoProvincias(request)).ToListAsync();

            return new BuscarProvinciasResponse(request){ Elementos = _mapper.Map<List<ProvinciaDTO>>(provincias.Paginate(request))};
        }

        public async Task<CrearProvinciaResponse> CrearProvincia(CrearProvinciaRequest request)
        {
            var provinciaNueva = _mapper.Map<Provincia>(request);
            _applicationDbContext.Provincias.Add(provinciaNueva);
            var id = await _applicationDbContext.SaveChangesAsync();
            
            return new CrearProvinciaResponse() { Id = id };
        }

        public async Task<ModificarProvinciaResponse> ModificarProvincia(ModificarProvinciaRequest request)
        {
            ModificarProvinciaResponse response = new ModificarProvinciaResponse();

            var provinciaAModificar = await _applicationDbContext.Provincias.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (provinciaAModificar != null)
            {
                provinciaAModificar.Nombre = request.Nombre;
                
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                response.AddError("Provincia", $"No se encontro la provincia con id: {request.Id}");
            }

            return response;
        }

        public async Task<ObtenerProvinciaResponse> ObtenerProvincia(ObtenerProvinciaRequest request)
        {
            ObtenerProvinciaResponse response = new ObtenerProvinciaResponse() { Encontrado = true };
            
            var provincia = await _applicationDbContext.Provincias.FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if (provincia == null)
            {
                response.Encontrado = false;
            }
            else
            {
                ProvinciaCompleta provinciaCompleta = new ProvinciaCompleta() 
                {
                    Id = provincia.Id,
                    Nombre = provincia.Nombre,
                    Ciudades = await _servicioCiudades.BuscarCiudades(new BuscarCiudadesRequest() { ProvinciaId = request.Id })
                };
                
                response.Provincia = provinciaCompleta;
            }
 
            return response;
        }

        private static Expression<Func<Provincia, bool>> ObtenerPredicadoProvincias(BuscarProvinciasRequest request)
        {
            var predicado = PredicateBuilder.New<Provincia>();

            if (!String.IsNullOrEmpty(request.Nombre))
            {
                predicado.And(x => x.Nombre.Contains(request.Nombre));
            }

            return predicado;
        }
    }
}