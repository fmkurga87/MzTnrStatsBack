using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MzTNR.Data.Data;

namespace MzTNR.Services.Extensiones
{
    internal class MetodosComunes
    {
        private ApplicationDbContext _applicationDbContext;
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
    }
}