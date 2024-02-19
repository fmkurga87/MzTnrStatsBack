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
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Partidos;
using MzTNR.Contracts.Partidos.DTOs;
using MzTNR.Contracts.Partidos.Modelos;
using MzTNR.Contracts.Partidos.RequetResponses;
using MzTNR.Data.Data;
using MzTNR.Data.Models.TNR;
using static MzTNR.Contracts.Partidos.DTOs.DetallePartidoXML;
using static MzTNR.Contracts.Partidos.DTOs.ListaPartidosXML;

namespace MzTNR.Services.Partidos
{
    public class ServicioPartidos : IServicioPartidos
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        
        public ServicioPartidos(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
            
        }
        public Task<BuscarPartidosResponse> BuscarPartidos(BuscarPartidosRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CrearPartidoResponse> CrearPartido(CrearPartidoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarPartidoResponse> ModificarPartido(ModificarPartidoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ObtenerPartidoResponse> ObtenerPartido(ObtenerPartidoRequest request)
        {
            return new ObtenerPartidoResponse() {
                Encontrado = true,
                Partido = await ObtenerFichaPartidoXML(request.Id)
            };
            
        }

        public async Task<List<ResumenPartido>> ObtenerPartidosXML(int idEquipo, int tipoPartidos)
        {
            // TODO: Agregar la inteligencia para guardar la info de los partidos que correspondan al TNR
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
                            partidoDeTNR = _applicationDbContext.Torneos.Any(x => x.IdMz == int.Parse(typeId));
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
                            resumenPartidoActual.EquipoLocal = teamName;
                            resumenPartidoActual.GolesLocal = Int32.Parse(goals);
                        }
                        else
                        {
                            resumenPartidoActual.EquipoVisitante = teamName;
                            resumenPartidoActual.GolesVisitante = Int32.Parse(goals);
                        }
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

            // TODO: Parsearlo manualmente, asi falla
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
                                                        Goals = new Goals
                                                        {
                                                            Pro = (int)p.Element("Goals").Attribute("pro"),
                                                            Own = (int)p.Element("Goals").Attribute("own")
                                                        },
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
                                                        Goals = new Goals
                                                        {
                                                            Pro = (int)p.Element("Goals").Attribute("pro"),
                                                            Own = (int)p.Element("Goals").Attribute("own")
                                                        },
                                                        Cards = (p.Element("Cards") != null) ? new Cards
                                                        {
                                                            Yellow = (int)p.Element("Cards").Attribute("yellow"),
                                                            Red = (int)p.Element("Cards").Attribute("red")
                                                        } : null
                                                    }).ToList()
                                     }).FirstOrDefault()
                     }).FirstOrDefault();

            // Console.WriteLine($"Match ID: {match.Id}");
            // Console.WriteLine($"Date: {match.Date}");
            // Console.WriteLine($"Type: {match.Type}");
            // Console.WriteLine($"Sport: {match.Sport}");
            // Console.WriteLine($"Spectators: {match.Spectators}");
            // Console.WriteLine($"Home Team: {match.HomeTeam.Name}");
            // Console.WriteLine($"Home Team Goals: {match.HomeTeam.Goals}");
            // Console.WriteLine($"Away Team: {match.AwayTeam.Name}");
            // Console.WriteLine($"Away Team Goals: {match.AwayTeam.Goals}");

            // Console.WriteLine("\nHome Team Players:");
            // foreach (var player in match.HomeTeam.Players)
            // {
            //     Console.WriteLine($"Player Name: {player.Name}");
            //     Console.WriteLine($"Shirt Number: {player.ShirtNumber}");
            //     Console.WriteLine($"Goals Scored: {player.Goals.Pro}");
            //     Console.WriteLine($"Own Goals: {player.Goals.Own}");
            //     if (player.Cards != null)
            //     {
            //         Console.WriteLine($"Yellow Cards: {player.Cards.Yellow}");
            //         Console.WriteLine($"Red Cards: {player.Cards.Red}");
            //     }
            //     Console.WriteLine();
            // }

            // Console.WriteLine("\nAway Team Players:");
            // foreach (var player in match.AwayTeam.Players)
            // {
            //     Console.WriteLine($"Player Name: {player.Name}");
            //     Console.WriteLine($"Shirt Number: {player.ShirtNumber}");
            //     Console.WriteLine($"Goals Scored: {player.Goals.Pro}");
            //     Console.WriteLine($"Own Goals: {player.Goals.Own}");
            //     if (player.Cards != null)
            //     {
            //         Console.WriteLine($"Yellow Cards: {player.Cards.Yellow}");
            //         Console.WriteLine($"Red Cards: {player.Cards.Red}");
            //     }
            //     Console.WriteLine();
            // }

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

        
    }
}