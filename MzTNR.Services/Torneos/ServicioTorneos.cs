using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Torneos;
using MzTNR.Contracts.Torneos.DTOs;
using MzTNR.Contracts.Torneos.Modelos;
using MzTNR.Contracts.Torneos.RequestResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;

namespace MzTNR.Services.Torneos
{
    public class ServicioTorneos : IServicioTorneos
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        
        public ServicioTorneos(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
            
        }
        public Task<BuscarTorneosResponse> BuscarTorneos(BuscarTorneosRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CrearTorneoResponse> CrearTorneo(CrearTorneoRequest request)
        {
            var torneoNuevo = _mapper.Map<Torneo>(request);
            _applicationDbContext.Torneos.Add(torneoNuevo);
            var id = await _applicationDbContext.SaveChangesAsync();
            
            return new CrearTorneoResponse() { Id = id };
        }

        public Task<ModificarTorneoResponse> ModificarTorneo(ModificarTorneoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ObtenerTorneoResponse> ObtenerTorneo(ObtenerTorneoRequest request)
        {
            ObtenerTorneoResponse obtenerTorneoResponse = new ObtenerTorneoResponse() {Encontrado = true};

            var torneo = await _applicationDbContext.Torneos.FirstOrDefaultAsync(x => x.IdMz == request.Id);

            if (torneo == null)
            {
                obtenerTorneoResponse.Encontrado = false;
                obtenerTorneoResponse.AddError("Torneo", $"No se encontro el torneo con id: {request.Id}");
            }
            else
            {
                obtenerTorneoResponse.Torneo = _mapper.Map<TorneoCompleto>(torneo);
                if (torneo.Tipo == 1)
                {
                    obtenerTorneoResponse.Torneo.DatosLA = ObtenerDatosLA(torneo.IdMz);
                }
                else
                {
                    // TODO: Obtener info de Copa
                }
                
            }

            return obtenerTorneoResponse;
        }

        private List<PosicionLigaAmistosa> ObtenerDatosLA(int idMzLA)
        {
            List<PosicionLigaAmistosa> posiciones = new List<PosicionLigaAmistosa>();

            string urlXmlLA = $"http://www.managerzone.com/xml/friendlyleague.php?sport_id=1&friendlyleague_id={idMzLA}";
            XDocument xmlLA = XDocument.Load(urlXmlLA);

            var teams = from team in xmlLA.Descendants("Team")
                select new
                {
                    Position = (int)team.Attribute("position"),
                    TeamId = (int)team.Attribute("teamId"),
                    TeamName = (string)team.Attribute("teamName"),
                    Played = (int)team.Attribute("played"),
                    Won = (int)team.Attribute("won"),
                    Drawn = (int)team.Attribute("drawn"),
                    Lost = (int)team.Attribute("lost"),
                    GoalsPlus = (int)team.Attribute("goalsPlus"),
                    GoalsMinus = (int)team.Attribute("goalsMinus"),
                    GoalsDifference = (int)team.Attribute("goalsDifference"),
                    Points = (int)team.Attribute("points")
                };

            foreach (var team in teams)
            {
                posiciones.Add( new PosicionLigaAmistosa() 
                {
                    TorneoId = idMzLA,
                    Posicion  = team.Position,
                    EquipoId  = team.TeamId,
                    PartidosJugados  = team.Played,
                    PartidosGanados  = team.Won,
                    PartidosEmpatados  = team.Drawn,
                    PartidosPerdidos  = team.Lost,
                    GolesAFavor  = team.GoalsPlus,
                    GolesEnContra  = team.GoalsMinus,
                    DiferenciaGol  = team.GoalsDifference,
                    Puntos  = team.Points,
                });
            }

            return posiciones;
        }
    }
}