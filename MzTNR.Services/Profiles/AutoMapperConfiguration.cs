using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MzTNR.Contracts.Ciudades.DTOs;
using MzTNR.Contracts.Ciudades.RequestResponses;
using MzTNR.Contracts.Equipos.Modelos;
using MzTNR.Contracts.Equipos.RequestResponses;
using MzTNR.Contracts.Provincias.DTOs;
using MzTNR.Contracts.Provincias.RequestResponses;
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

            #region Provincias
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<CrearProvinciaRequest, Provincia>();
            #endregion
            
            #region Equipos
            CreateMap<Equipo, ResumenEquipo>();
            CreateMap<CrearEquipoRequest, Equipo>();
            #endregion
        }   
    }
}