using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Partidos.Modelos;
using MzTNR.Contracts.Torneos;
using MzTNR.Contracts.Torneos.DTOs;
using MzTNR.Contracts.Torneos.Modelos;
using MzTNR.Contracts.Torneos.RequestResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;
using MzTNR.Services.Extensiones;

namespace MzTNR.Services.Torneos
{
    public class ServicioTorneos : IServicioTorneos
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly MetodosComunes _metodosComunes;
        
        public ServicioTorneos(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
            _metodosComunes = new MetodosComunes(_applicationDbContext);
        }
        public async Task<BuscarTorneosResponse> BuscarTorneos(BuscarTorneosRequest request)
        {
            var torneos = _applicationDbContext.Torneos.Where(ObtenerPredicadoTorneos(request)).Paginate(request);

            return new BuscarTorneosResponse(request){ Elementos = _mapper.Map<List<TorneoDTO>>(torneos)};
        }

        public async Task<BuscarTorneosResponse> BuscarTorneosMock(int cant)
        {
            BuscarTorneosRequest requestFalso = new BuscarTorneosRequest() {
                CantidadPagina = cant,
                NumeroPagina = 1,
            };
            
            var torneos = _applicationDbContext.Torneos.OrderByDescending(x => x.FechaInicio).Paginate(requestFalso);

            return new BuscarTorneosResponse(requestFalso){ Elementos = _mapper.Map<List<TorneoDTO>>(torneos)};
        }

        public async Task<CrearTorneoResponse> CrearTorneo(CrearTorneoRequest request)
        {
            var torneoNuevo = _mapper.Map<Torneo>(request);
            _applicationDbContext.Torneos.Add(torneoNuevo);
            var id = await _applicationDbContext.SaveChangesAsync();
            
            return new CrearTorneoResponse() { Id = id };
        }

        public async Task<CrearGrupoCopaResponse> CrearGrupoCopa(CrearGrupoCopaRequest request)
        {
            CrearGrupoCopaResponse response = new CrearGrupoCopaResponse();
            // TODO: Agregar validaciones y controles por PK

            if (response.Errores.Count == 0)
            {
                foreach (var equipo in request.EquiposGrupo)
                {
                    await _metodosComunes.ValidarEquipo(equipo.IdMz.Value, equipo.NombreEquipo);

                    FaseGrupo faseGrupo = new FaseGrupo()
                    {
                        TorneoId = request.TorneoId,
                        Grupo = request.Grupo,
                        EquipoId = equipo.IdMz.Value,
                    };

                    _applicationDbContext.FasesGrupos.Add(faseGrupo);
                }

                await _applicationDbContext.SaveChangesAsync();
            }

            return response;
        }

        public async Task<ModificarTorneoResponse> ModificarTorneo(ModificarTorneoRequest request)
        {
            ModificarTorneoResponse response = new ModificarTorneoResponse() { Encontrado = true};

            var torneo = await _applicationDbContext.Torneos.FirstOrDefaultAsync(x => x.IdMz == request.Id);

            if (torneo == null)
            {
                response.Encontrado = false;
                response.AddError("Torneo", $"No se encontro el torneo con id: {request.Id}");
            }
            else
            {
                torneo.Tipo = (int)request.Tipo;
                torneo.IdMz = request.IdMz;
                torneo.Nombre = request.Nombre;
                torneo.Edicion = request.Edicion;
                torneo.TemporadaMZ = request.TemporadaMZ;
                torneo.FechaInicio = request.FechaInicio;
                torneo.FechaFin = request.FechaFin;
                torneo.Link = request.Link;
                torneo.IdCampeon = request.IdCampeon;
                torneo.UrlImagen = request.UrlImagen;
            }

            await _applicationDbContext.SaveChangesAsync();

            return response;
        }

        public async Task<CargarUrlImagenResponse> CargarUrlImagen(CargarUrlImagenRequest request)
        {
             CargarUrlImagenResponse response = new CargarUrlImagenResponse() { Ok = true};

            var torneo = await _applicationDbContext.Torneos.FirstOrDefaultAsync(x => x.IdMz == request.IdTorneo);

            if (torneo == null)
            {
                response.Ok = false;
                response.AddError("Torneo", $"No se encontro el torneo con id: {request.IdTorneo}");
            }
            else
            {
                torneo.UrlImagen = request.UrlImagen;
            }

            await _applicationDbContext.SaveChangesAsync();

            return response;
        }

        
        public async Task<ObtenerTorneoResponse> ObtenerTorneo(ObtenerTorneoRequest request)
        {
            // NOTA: Los partidos y playoffs se cargan en el Servicio Partidos
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
                    obtenerTorneoResponse.Torneo.DatosLA = await ObtenerDatosLA(torneo.IdMz);
                }
                else
                {
                    obtenerTorneoResponse.Torneo.DatosCopa = await ObtenerDatosCopa(torneo.IdMz);
                }
                
            }

            return obtenerTorneoResponse;
        }

        public async Task<ListarTorneosResponse> ListarTorneos()
        {
            List<TorneoListaDTO> torneoListaDTO = new List<TorneoListaDTO>();

            var torneos = _applicationDbContext.Torneos.OrderByDescending(x => x.TemporadaMZ).ToList();

            foreach (var temporada in torneos.Select(x => x.TemporadaMZ).Distinct())
            {
                torneoListaDTO.Add( new TorneoListaDTO() { TemporadaMZ = temporada,
                    Torneos = _mapper.Map<List<ResumenTorneoDTO>>(torneos.Where(x => x.TemporadaMZ == temporada).ToList()) 
                });
            }

            return new ListarTorneosResponse() { TorneosPorTemporada = torneoListaDTO };
        }

        public async Task<ListarTorneosResponse> ListarTorneosPorEquipo(int IdMzEquipo)
        {
            List<TorneoListaDTO> torneoListaDTO = new List<TorneoListaDTO>();
            
            var torneosIds = await _applicationDbContext.LigasAmistosas.Where(x => x.EquipoId == IdMzEquipo).Select(y => y.IdMz).ToListAsync();
            torneosIds.AddRange(await _applicationDbContext.FasesGrupos.Where(x => x.EquipoId == IdMzEquipo && x.TorneoId.HasValue).Select(y => y.TorneoId.Value).ToListAsync());

            var torneosDeEquipo = _applicationDbContext.Torneos.Where(x => torneosIds.Contains(x.IdMz)).OrderByDescending(x => x.TemporadaMZ).ToList();
            
            foreach (var temporada in torneosDeEquipo.Select(x => x.TemporadaMZ).Distinct())
            {
                torneoListaDTO.Add( new TorneoListaDTO() { TemporadaMZ = temporada,
                    Torneos = _mapper.Map<List<ResumenTorneoDTO>>(torneosDeEquipo.Where(x => x.TemporadaMZ == temporada).ToList()) 
                });
            }

            return new ListarTorneosResponse() { TorneosPorTemporada = torneoListaDTO };
        }
    

        private static Expression<Func<Torneo, bool>> ObtenerPredicadoTorneos(BuscarTorneosRequest request)
        {
            var predicado = PredicateBuilder.New<Torneo>();

            if (request.IdMz.HasValue)
            {
                predicado.And(x => x.IdMz == request.IdMz.Value);
            }

            if (!String.IsNullOrEmpty(request.Nombre))
            {
                predicado.And(x => x.Nombre.Contains(request.Nombre));
            }

            if (request.Edicion.HasValue)
            {
                predicado.And(x => x.Edicion == request.Edicion.Value);
            }

            if (request.TemporadaMZ.HasValue)
            {
                predicado.And(x => x.TemporadaMZ == request.TemporadaMZ.Value);
            }

            if (request.IdEquipo.HasValue)
            {
                // TODO: Hacer un navigation para encontrar los torneos del equipo
                //predicado.And(x => x.IdMz == request.IdMz.Value);
            }

            if (request.Fecha.HasValue)
            {
                predicado.And(x => x.FechaInicio.Value.AddDays(-7) <= request.Fecha.Value && request.Fecha.Value <= x.FechaFin.Value.AddDays(10));
            }
            else
            {
                predicado.And(x => x.FechaInicio.Value.AddDays(-7) <= DateTime.Today && DateTime.Today <= x.FechaFin.Value.AddDays(10));
            }

            return predicado;
        }

        private async Task<List<PosicionLigaAmistosa>> ObtenerDatosLA(int idMzLA)
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
                PosicionLigaAmistosa posicionLigaAmistosa =  new PosicionLigaAmistosa() 
                {
                    TorneoId = idMzLA,
                    Posicion  = team.Position,
                    EquipoId  = team.TeamId,
                    EquipoNombre = team.TeamName,
                    PartidosJugados  = team.Played,
                    PartidosGanados  = team.Won,
                    PartidosEmpatados  = team.Drawn,
                    PartidosPerdidos  = team.Lost,
                    GolesAFavor  = team.GoalsPlus,
                    GolesEnContra  = team.GoalsMinus,
                    DiferenciaGol  = team.GoalsDifference,
                    Puntos  = team.Points,
                };

                await ActualizarLA(posicionLigaAmistosa);
                
                posiciones.Add(posicionLigaAmistosa);
            }

            return posiciones;
        }

        private async Task<Copa> ObtenerDatosCopa(int idMzCopa)
        {
            Copa copa = new Copa();

            var grupos = _applicationDbContext.FasesGrupos.Where(x => x.TorneoId == idMzCopa).Select(y => y.Grupo).Distinct().ToList();

            if (grupos.Any())
            {
                List<GrupoCopaConPartidos> listaGrupos = new List<GrupoCopaConPartidos>();
                // Uso foreach porque maneja mejor el async que grupos.ForEach
                foreach (var grupo in grupos)
                {
                    var datosGrupoActual = await ObtenerGrupoCopaAsync(idMzCopa, grupo);
                    listaGrupos.Add(datosGrupoActual);
                }

                copa.Grupos = listaGrupos;    
            }
            
            copa.Playoff = await ObtenerPlayoffs(idMzCopa);
            
            return copa;
        } 

        private async Task<GrupoCopaConPartidos> ObtenerGrupoCopaAsync(int idTorneo, string grupo)
        {
            //Id para test: 306874
            var equiposGrupo = _mapper.Map<List<EquipoGrupoCopa>>(_applicationDbContext.FasesGrupos.Where(x => x.TorneoId == idTorneo && x.Grupo == grupo)
                                                                                                    .Include(x => x.Equipo)
                                                                                                    .ToList());

            List<ResumenPartido> partidosDelGrupo = new List<ResumenPartido>();

            var partidosGrupo = await _applicationDbContext.Partidos.Where(x => x.TorneoId == idTorneo
                                                                        && x.TipoPartido == 6
                                                                        && equiposGrupo.Select(y => y.EquipoId).Contains(x.EquipoLocalId)
                                                                         )
                                                                    .Include(x => x.EquipoLocal).Include(x => x.EquipoVisitante)
                                                                    .ToListAsync();

            partidosGrupo.ForEach( x => {
                    var local = equiposGrupo.First(y => y.EquipoId == x.EquipoLocalId);
                    var visitante = equiposGrupo.First(y => y.EquipoId == x.EquipoVisitanteId);
                    local.PartidosJugados++;
                    local.GolesAFavor += x.GolesLocal;
                    local.GolesEnContra += x.GolesVisitante;
                    visitante.PartidosJugados++;
                    visitante.GolesAFavor += x.GolesVisitante;
                    visitante.GolesEnContra += x.GolesLocal;
                    
                    if (x.GolesLocal > x.GolesVisitante)
                    {
                        local.PartidosGanados++;
                        local.Puntos += 3;
                        visitante.PartidosPerdidos++;
                    }
                    else if (x.GolesVisitante > x.GolesLocal)
                    {
                        local.PartidosPerdidos++;
                        visitante.PartidosGanados++;
                        visitante.Puntos += 3;
                    }
                    else
                    {
                        local.PartidosEmpatados++;
                        local.Puntos++;
                        visitante.PartidosEmpatados++;
                        visitante.Puntos++;
                    }
                    local.DiferenciaGol = local.GolesAFavor - local.GolesEnContra;
                    visitante.DiferenciaGol = visitante.GolesAFavor - visitante.GolesEnContra;
                    
                    partidosDelGrupo.Add(_mapper.Map<ResumenPartido>(x));
                }
            ); 

            GrupoCopaConPartidos grupoCopa = new GrupoCopaConPartidos
            {
                Grupo = grupo,
                EquiposGrupo = equiposGrupo.OrderByDescending(x => x.Puntos).ThenByDescending(x => x.DiferenciaGol).ThenByDescending(x => x.GolesAFavor).ToList(),
                PartidosDelGrupo = partidosDelGrupo
            };

            return grupoCopa;
        }

        private async Task<List<EliminatoriasCopa>> ObtenerPlayoffs(int idTorneo)
        {
            //307061
            List<EliminatoriasCopa> eliminatoriasCopas = new List<EliminatoriasCopa>();

            var partidosPlayoff = await _applicationDbContext.Partidos.Where(x => x.TorneoId == idTorneo
                                                                        && x.TipoPartido == 7)
                                                                        .Include(p => p.EquipoLocal)
                                                                        .Include(p => p.EquipoVisitante)
                                                                        .ToListAsync();

            partidosPlayoff.ForEach( x => {
                var instancia = eliminatoriasCopas.FirstOrDefault(y => (int)y.Instancia == x.Instancia);
                if (instancia == null)
                {
                    var listaPartidos = new List<ResumenPartido>
                    {
                        _mapper.Map<Partido, ResumenPartido>(x, opt =>
                        opt.AfterMap((src, dest) => 
                        {
                            dest.EquipoLocal = src.EquipoLocal.NombreEquipo;
                            dest.EquipoVisitante = src.EquipoVisitante.NombreEquipo;
                        }))
                    };
                    
                    eliminatoriasCopas.Add(new EliminatoriasCopa(){ Instancia = EnumInstanciaPartido.Indeterminada, 
                                                                    Partidos = listaPartidos});
                }
                else
                {
                    instancia.Partidos.Add(_mapper.Map<ResumenPartido>(x));
                };

            });                                                                       

            return eliminatoriasCopas;    
        }

        private async Task ActualizarLA(PosicionLigaAmistosa posicionLigaAmistosa)
        {
            var liga = await _applicationDbContext.LigasAmistosas.FirstOrDefaultAsync(x => x.IdMz == posicionLigaAmistosa.TorneoId && x.Posicion == posicionLigaAmistosa.Posicion);

            if (liga == null)
            {
                await _metodosComunes.ValidarEquipo(posicionLigaAmistosa.EquipoId.Value, posicionLigaAmistosa.EquipoNombre);

                _applicationDbContext.LigasAmistosas.Add( new LigaAmistosa() {
                    IdMz = posicionLigaAmistosa.TorneoId.Value,
                    Posicion = posicionLigaAmistosa.Posicion,
                    EquipoId = posicionLigaAmistosa.EquipoId.Value,
                    PartidosGanados = posicionLigaAmistosa.PartidosGanados,
                    PartidosEmpatados = posicionLigaAmistosa.PartidosEmpatados,
                    PartidosPerdidos = posicionLigaAmistosa.PartidosPerdidos,
                    GolesAFavor = posicionLigaAmistosa.GolesAFavor,
                    GolesEnContra = posicionLigaAmistosa.GolesEnContra
                });

                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                if (liga.PartidosGanados + liga.PartidosEmpatados + liga.PartidosPerdidos != posicionLigaAmistosa.PartidosJugados)
                {
                    liga.EquipoId = posicionLigaAmistosa.EquipoId.Value;
                    liga.PartidosGanados = posicionLigaAmistosa.PartidosGanados;
                    liga.PartidosEmpatados = posicionLigaAmistosa.PartidosEmpatados;
                    liga.PartidosPerdidos = posicionLigaAmistosa.PartidosPerdidos;
                    liga.GolesAFavor = posicionLigaAmistosa.GolesAFavor;
                    liga.GolesEnContra = posicionLigaAmistosa.GolesEnContra;

                    await _applicationDbContext.SaveChangesAsync();
                }
            }

            return;
        }

        
    }
}