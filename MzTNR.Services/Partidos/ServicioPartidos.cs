using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Equipos;
using MzTNR.Contracts.Partidos;
using MzTNR.Contracts.Partidos.DTOs;
using MzTNR.Contracts.Partidos.Modelos;
using MzTNR.Contracts.Partidos.RequetResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;
using MzTNR.Services.Extensiones;
using static MzTNR.Contracts.Partidos.DTOs.DetallePartidoXML;
using static MzTNR.Contracts.Partidos.DTOs.ListaPartidosXML;

namespace MzTNR.Services.Partidos
{
    public class ServicioPartidos : IServicioPartidos
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly MetodosComunes _metodosComunes;
        
        public ServicioPartidos(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
            _metodosComunes = new MetodosComunes(_applicationDbContext);
        }
        public Task<BuscarPartidosResponse> BuscarPartidos(BuscarPartidosRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<CrearPartidoResponse> CrearPartido(CrearPartidoRequest request)
        {
            CrearPartidoResponse crearPartidoResponse = new CrearPartidoResponse();
            
            #region Validaciones
            if (_applicationDbContext.Partidos.Any(x => x.IdMz == request.IdMz))
            {
                crearPartidoResponse.AddError("Partido", "El partido ya fue creado.");
            }

            if (request.EquipoLocalId == 0 || request.EquipoVisitanteId == 0)
            {
                crearPartidoResponse.AddError("Equipo", "El equipo local y/o el equipo visitante no fue encontrado.");
            }

            if (request.TorneoId == 0)
            {
                crearPartidoResponse.AddError("Torneo", "El torneo no fue encontrado.");
            }
            #endregion

            if (crearPartidoResponse.Errores.Count() == 0)
            {
                var partidoNuevo = _mapper.Map<Partido>(request);
                _applicationDbContext.Partidos.Add(partidoNuevo);
                crearPartidoResponse.Id = await _applicationDbContext.SaveChangesAsync();
            }
            
            return crearPartidoResponse;

        }

        public Task<ModificarPartidoResponse> ModificarPartido(ModificarPartidoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ObtenerPartidoResponse> ObtenerPartido(ObtenerPartidoRequest request)
        {
            var partidoXML  = await ObtenerFichaPartidoXML(request.Id);

            return new ObtenerPartidoResponse() {
                Encontrado = partidoXML.Id == 0 ? false : true,
                Partido = partidoXML
            };
            
        }

        public async Task<CargarResultadoResponse> CargarResultado(CargarResultadoRequest request)
        {
            CargarResultadoResponse cargarResultadoResponse = new CargarResultadoResponse (){ Encontrado = true };

            var partido = _applicationDbContext.Partidos.FirstOrDefault(x => x.IdMz == request.IdPartido);

            if (partido != null)
            {
                partido.GolesLocal = request.GolesLocal;
                partido.GolesVisitante = request.GolesVisitante;

                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                cargarResultadoResponse.Encontrado = false;
                cargarResultadoResponse.AddError("Partido", $"Partido con Id {request.IdPartido} no encontrado");
            }

            return cargarResultadoResponse;
        }

        public async Task<BuscarHistorialResponse> BuscarHistorial(BuscarHistorialRequest request)
        {
            BuscarHistorialResponse buscarHistorialResponse = new BuscarHistorialResponse ();

            var partidos = await _applicationDbContext.Partidos
                                                        .Where(x => x.Fecha < DateTime.Now &&
                                                                    ((x.EquipoLocalId == request.IdEquipo1 && x.EquipoVisitanteId == request.IdEquipo2)
                                                                ||  (x.EquipoVisitanteId == request.IdEquipo1 && x.EquipoLocalId == request.IdEquipo2 )))
                                                        .Include(p => p.Torneo).Include(p => p.EquipoLocal).Include(p => p.EquipoVisitante)
                                                        .ToListAsync();

            if (partidos.Count > 0)
            {
                buscarHistorialResponse.TotalPartidos = partidos.Count();
                buscarHistorialResponse.GanadosEquipo1 = partidos.Where( x => (x.EquipoLocalId == request.IdEquipo1 && x.GolesLocal > x.GolesVisitante)
                                                                        ||  (x.EquipoVisitanteId == request.IdEquipo1 && x.GolesLocal < x.GolesVisitante)).Count();
                buscarHistorialResponse.Empatados = partidos.Where(x => x.GolesLocal == x.GolesVisitante).Count();
                buscarHistorialResponse.GanadosEquipo2 = buscarHistorialResponse.TotalPartidos - buscarHistorialResponse.GanadosEquipo1 - buscarHistorialResponse.Empatados;

                List<ResumenPartido> listaPartidos = new List<ResumenPartido>();
                foreach (var partido in partidos)
                {
                    listaPartidos.Add( new ResumenPartido()
                    {
                        TipoPartido = 0,
                        EsTNR = true,
                        IdTorneo = partido.TorneoId,
                        NombreTorneo = partido.Torneo?.Nombre,
                        EquipoLocal = partido.EquipoLocal?.NombreEquipo,
                        GolesLocal = partido.GolesLocal,
                        EquipoVisitante = partido.EquipoVisitante?.NombreEquipo,
                        GolesVisitante = partido.GolesVisitante,
                    });
                }

                buscarHistorialResponse.Partidos = listaPartidos;
            }
            else
            {
                buscarHistorialResponse.AddError ("Partidos", "No se encontraron partidos jugados entre los equipos seleccionados");
            }
            
            return buscarHistorialResponse;
        }

        public async Task<List<ResumenPartido>> ObtenerPartidosXML(int idEquipo, int tipoPartidos)
        {
            List<ResumenPartido> resumenPartidos = new List<ResumenPartido>();

            // Obtengo el XML
            string urlXmlPartidos = $"http://www.managerzone.com/xml/team_matchlist.php?sport_id=1&team_id={idEquipo}&match_status={tipoPartidos}&limit=50";
            XDocument xmlPartidos = XDocument.Load(urlXmlPartidos);

            // Lo proceso
            if (xmlPartidos != null && xmlPartidos.Root != null && xmlPartidos.Root.HasElements)
            {
                foreach (XElement matchElement in xmlPartidos.Root.Elements("Match"))
                {
                    ResumenPartido resumenPartidoActual = new ResumenPartido();
                    string id = matchElement.Attribute("id")?.Value ?? "";
                    string date = matchElement.Attribute("date")?.Value ?? "";
                    string status = matchElement.Attribute("status")?.Value ?? "";
                    string type = matchElement.Attribute("type")?.Value ?? "";
                    string typeName = matchElement.Attribute("typeName")?.Value ?? "";
                    string typeId = matchElement.Attribute("typeId")?.Value ?? "";

                    bool partidoDeTNR = false;
                    int idLocal = 0;
                    int idVisitante = 0;

                    if (type == "")
                    {
                        resumenPartidoActual.TipoPartido = EnumTipoPartidoEng.other;
                        resumenPartidoActual.EsTNR = partidoDeTNR;
                        resumenPartidoActual.NombreTorneo = "";
                    }
                    else
                    {
                        // Verificamos si pertenece al TNR
                        if (type != "friendly")
                        {
                            partidoDeTNR = await _applicationDbContext.Torneos.AnyAsync(x => x.IdMz == int.Parse(typeId));
                        }
                                                
                        resumenPartidoActual.TipoPartido = Enum.Parse<EnumTipoPartidoEng>(type);
                        resumenPartidoActual.EsTNR = partidoDeTNR;
                        resumenPartidoActual.NombreTorneo = typeName;
                    }

                    foreach (XElement teamElement in matchElement.Elements("Team"))
                    {
                        string teamField = teamElement.Attribute("field")?.Value ?? "";
                        string goals = teamElement.Attribute("goals")?.Value ?? "";
                        string teamId = teamElement.Attribute("teamId")?.Value ?? "";
                        string teamName = teamElement.Attribute("teamName")?.Value ?? "";
                        string countryShortname = teamElement.Attribute("countryShortname")?.Value ?? "";

                        if (teamField == "home")
                        {
                            idLocal = partidoDeTNR ? await _metodosComunes.ValidarEquipo(Int32.Parse(teamId), teamName) : 0;
                            resumenPartidoActual.EquipoLocal = teamName;
                            resumenPartidoActual.GolesLocal = Int32.Parse(goals);
                        }
                        else
                        {
                            idVisitante = partidoDeTNR ? await _metodosComunes.ValidarEquipo(Int32.Parse(teamId), teamName) : 0;
                            resumenPartidoActual.EquipoVisitante = teamName;
                            resumenPartidoActual.GolesVisitante = Int32.Parse(goals);
                        }
                    }

                    if (partidoDeTNR)
                    {
                        resumenPartidoActual.IdTorneo = Int32.Parse(typeId);
                        await this.AlmacenarPartido(int.Parse(id), idLocal, resumenPartidoActual.GolesLocal, idVisitante, resumenPartidoActual.GolesVisitante, DateTime.Parse(date), int.Parse(typeId));
                    }

                    resumenPartidos.Add(resumenPartidoActual);
                }

            }

            return resumenPartidos;
        }

        public async Task<DetallePartidoXML> ObtenerFichaPartidoXML(int idPartido)
        {
            DetallePartidoXML detallePartidoXML = new DetallePartidoXML();
            
            // Obtengo el XML
            string urlXmlPartidos = $"http://www.managerzone.com/xml/match_info.php?sport_id=1&match_id={idPartido}";
            XDocument xmlPartidos = XDocument.Load(urlXmlPartidos);

            if (xmlPartidos.Descendants("Match").Any())
            {
                detallePartidoXML = (from m in xmlPartidos.Descendants("Match")
                    select new DetallePartidoXML
                    {
                        Id = (int)m.Attribute("id"),
                        Date = DateTime.Parse((string)m.Attribute("date")),
                        Type = (int)m.Attribute("type"),
                        Sport = (string)m.Attribute("sport"),
                        Spectators = (int)m.Attribute("spectators"),
                        HomeTeam = (from t in m.Elements("Team")
                                    where (string)t.Attribute("field") == "home"
                                    select new TeamMatch
                                    {
                                        Id = (int)t.Attribute("id"),
                                        Name = (string)t.Attribute("name"),
                                        ShortName = (string)t.Attribute("shortname"),
                                        Country = (string)t.Attribute("country"),
                                        Field = (string)t.Attribute("field"),
                                        Goals = (int)t.Attribute("goals"),
                                        Players = (from p in t.Elements("Player")
                                                    select new PlayerMatch
                                                    {
                                                        Id = (int)p.Attribute("id"),
                                                        Name = (string)p.Attribute("name"),
                                                        ShirtNumber = (int)p.Attribute("shirtno"),
                                                        Goals = (p.Element("Goals") != null) ? new Goals
                                                        {
                                                            Pro = (int)p.Element("Goals").Attribute("pro"),
                                                            Own = (int)p.Element("Goals").Attribute("own")
                                                        } : null,
                                                        Cards = (p.Element("Cards") != null) ? new Cards
                                                        {
                                                            Yellow = (int)p.Element("Cards").Attribute("yellow"),
                                                            Red = (int)p.Element("Cards").Attribute("red")
                                                        } : null
                                                    }).ToList()
                                     }).FirstOrDefault(),

                        AwayTeam = (from t in m.Elements("Team")
                                    where (string)t.Attribute("field") == "away"
                                    select new TeamMatch
                                    {
                                        Id = (int)t.Attribute("id"),
                                        Name = (string)t.Attribute("name"),
                                        ShortName = (string)t.Attribute("shortname"),
                                        Country = (string)t.Attribute("country"),
                                        Field = (string)t.Attribute("field"),
                                        Goals = (int)t.Attribute("goals"),
                                        Players = (from p in t.Elements("Player")
                                                    select new PlayerMatch
                                                    {
                                                        Id = (int)p.Attribute("id"),
                                                        Name = (string)p.Attribute("name"),
                                                        ShirtNumber = (int)p.Attribute("shirtno"),
                                                        Goals = (p.Element("Goals") != null) ? new Goals
                                                        {
                                                            Pro = (int)p.Element("Goals").Attribute("pro"),
                                                            Own = (int)p.Element("Goals").Attribute("own")
                                                        } : null,
                                                        Cards = (p.Element("Cards") != null) ? new Cards
                                                        {
                                                            Yellow = (int)p.Element("Cards").Attribute("yellow"),
                                                            Red = (int)p.Element("Cards").Attribute("red")
                                                        } : null
                                                    }).ToList()
                                     }).FirstOrDefault()
                     }).FirstOrDefault();
            }            

            return detallePartidoXML;
        }

        private static Expression<Func<Partido, bool>> ObtenerPredicadoPartidos(BuscarPartidosRequest request)
        {
            var predicado = PredicateBuilder.New<Partido>();

            if (request.idEquipo.HasValue)
            {
                predicado.And(x => x.EquipoLocalId == request.idEquipo || x.EquipoVisitanteId == request.idEquipo);
            }

            if (request.idTorneo.HasValue)
            {
                predicado.And(x => x.TorneoId == request.idTorneo);
            }

            return predicado;
        }

        private async Task AlmacenarPartido(int idPartido, int idLocal, int golesLocal, int idVisitante, int golesVisitante, DateTime fecha, int torneoId)
        {
            if (await _applicationDbContext.Partidos.AnyAsync(x => x.IdMz == idPartido))
            {
                await this.CargarResultado(new CargarResultadoRequest() 
                {
                    IdPartido = idPartido,
                    GolesLocal = golesLocal,
                    GolesVisitante = golesVisitante,
                });
            }
            else
            {
                await this.CrearPartido(new CrearPartidoRequest() 
                {
                    IdMz = idPartido,
                    EquipoLocalId = idLocal,
                    GolesLocal = golesLocal,
                    EquipoVisitanteId = idVisitante,
                    GolesVisitante = golesVisitante,
                    Fecha = fecha,
                    FechaNumero = 0,
                    TorneoId = torneoId // await _metodosComunes.ObtenerIdTorneo(int.Parse(typeId)),
                });
            }
            
            return;
        }
    }
}