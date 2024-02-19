using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MzTNR.Contracts.Partidos.DTOs
{
    public class DetallePartidoXML
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string Sport { get; set; }
        public int Spectators { get; set; }
        public TeamMatch HomeTeam { get; set; }
        public TeamMatch AwayTeam { get; set; }
       

        public class TeamMatch
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
            public string Country { get; set; }
            public string Field { get; set; }
            public int Goals { get; set; }
            public List<PlayerMatch> Players { get; set; }
        }

        public class PlayerMatch
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ShirtNumber { get; set; }
            public Goals Goals { get; set; }
            public Cards Cards { get; set; }
        }

        public class Goals
        {
            public int Pro { get; set; }
            public int Own { get; set; }
        }

        public class Cards
        {
            public int Yellow { get; set; }
            public int Red { get; set; }
        }

    }
}