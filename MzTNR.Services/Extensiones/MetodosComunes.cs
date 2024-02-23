using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Equipos.RequestResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;

namespace MzTNR.Services.Extensiones
{
    internal class MetodosComunes
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IServicioEquipos _servicioEquipos;

        internal MetodosComunes(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        } 

        internal async Task<int> ObtenerIdEquipo(int IdEquipoMz)
        {
            var equipo = await _applicationDbContext.Equipos.FirstOrDefaultAsync(x => x.IdMz == IdEquipoMz);

            if (equipo != null)
                return equipo.Id;
            else
                return 0;
        }

        internal async Task<int> ObtenerIdTorneo(int IdTorneoMz)
        {
            var torneo = await _applicationDbContext.Torneos.FirstOrDefaultAsync(x => x.IdMz == IdTorneoMz);

            if (torneo != null)
                return torneo.Id;
            else
                return 0;
        }

        internal async Task<int> ValidarEquipo(int IdEquipoMz, string NombreEquipo)
        {
            var equipo = await _applicationDbContext.Equipos.FirstOrDefaultAsync(x => x.IdMz == IdEquipoMz);

            if (equipo == null)
            {
                // TODO: Ver  si esto se puede hacer llamando al servicioEquipos son que haya loop con la DI.
                _applicationDbContext.Equipos.Add(new Equipo() {IdMz = IdEquipoMz, NombreEquipo = NombreEquipo});

                return await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                return equipo.Id;
            }
        }
    }
}