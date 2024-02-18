using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using MzTNR.Contracts.Compartidos;
using MzTNR.Contracts.Partidos;
using MzTNR.Contracts.Partidos.DTOs;
using MzTNR.Contracts.Partidos.Modelos;
using MzTNR.Data.Data;
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

        public async Task<List<ResumenPartido>> ObtenerPartidosXML(int idEquipo, int tipoPartidos)
        {
            // TODO: Agregar la inteligencia para guardar la info de los partidos que correspondan al TNR (identificarlos en la respuesta para que front los destaque)
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

        // TODO: Crear ObtenerFichaPartidoXML que llame al XML https://www.managerzone.com/?p=xml_content&xid=16 => http://www.managerzone.com/xml/match_info.php?sport_id=1&match_id=45646
    }
}