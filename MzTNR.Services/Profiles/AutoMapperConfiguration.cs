using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MzTNR.Contracts.Ciudades.DTOs;
using MzTNR.Contracts.Ciudades.RequestResponses;
using MzTNR.Contracts.Equipos.Modelos;
using MzTNR.Contracts.Equipos.RequestResponses;
using MzTNR.Contracts.Partidos.DTOs;
using MzTNR.Contracts.Partidos.RequetResponses;
using MzTNR.Contracts.Provincias.DTOs;
using MzTNR.Contracts.Provincias.RequestResponses;
using MzTNR.Contracts.Torneos.DTOs;
using MzTNR.Contracts.Torneos.Modelos;
using MzTNR.Contracts.Torneos.RequestResponses;
using MzTNR.Data.Models.TNR;

namespace MzTNR.Services.Profiles
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            #region Ciudades
            CreateMap<Ciudad, CiudadDTO>();
            CreateMap<CrearCiudadRequest, Ciudad>();
            #endregion

            #region Equipos
            CreateMap<Equipo, ResumenEquipo>();
            CreateMap<CrearEquipoRequest, Equipo>();
            #endregion
            
            #region Partidos
            CreateMap<Partido, PartidoDTO>();
            CreateMap<CrearPartidoRequest, Partido>();
            #endregion

            #region Provincias
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<ProvinciaCsv, Provincia>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(source => int.Parse(source.id)))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(source => source.nombre))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<CrearProvinciaRequest, Provincia>();
            #endregion

            #region Torneos
                // TODO: Agregar mapeo a la URL de imagen del torneo
                CreateMap<Torneo, TorneoDTO>();
                CreateMap<Torneo, TorneoCompleto>();
                CreateMap<CrearTorneoRequest, Torneo>();
            #endregion

        }   
    }
}