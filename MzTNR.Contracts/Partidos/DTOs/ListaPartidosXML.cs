using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MzTNR.Contracts.Partidos.DTOs
{

    public class ListaPartidosXML
    {
        public List<Match> Matches { get; set; }

        public class Match 
        { 
            public List<Team> Team { get; set; } 
            public int Id { get; set; } 
            public DateTime Date { get; set; } 
            public string Status { get; set; } 
            public string TypeName { get; set; } 
            public int TypeId { get; set; } 
        }

        public class Team 
        { 
            public string Field { get; set; } 
            public int Goals { get; set; } 
            public int TeamId { get; set; } 
            public string TeamName { get; set; } 
            public string CountryShortname { get; set; } 
        }
    }
}