using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MzTNR.Contracts.Partidos.DTOs
{
    public class PartidoXML
    {
        [XmlRoot(ElementName="Team")]
        public class Team { 

            [XmlAttribute(AttributeName="field")] 
            public string Field { get; set; } 

            [XmlAttribute(AttributeName="goals")] 
            public int Goals { get; set; } 

            [XmlAttribute(AttributeName="teamId")] 
            public int TeamId { get; set; } 

            [XmlAttribute(AttributeName="teamName")] 
            public string TeamName { get; set; } 

            [XmlAttribute(AttributeName="countryShortname")] 
            public string CountryShortname { get; set; } 
        }

        [XmlRoot(ElementName="Match")]
        public class Match { 

            [XmlElement(ElementName="Team")] 
            public List<Team> Team { get; set; } 

            [XmlAttribute(AttributeName="id")] 
            public int Id { get; set; } 

            [XmlAttribute(AttributeName="date")] 
            public DateTime Date { get; set; } 

            [XmlAttribute(AttributeName="status")] 
            public string Status { get; set; } 

            [XmlAttribute(AttributeName="type")] 
            public string Type { get; set; } 

            [XmlAttribute(AttributeName="typeName")] 
            public string TypeName { get; set; } 

            [XmlAttribute(AttributeName="typeId")] 
            public int TypeId { get; set; } 
        }

        [XmlRoot(ElementName="ManagerZone_MatchList")]
        public class ManagerZoneMatchList { 

            [XmlElement(ElementName="Match")] 
            public List<Match> Match { get; set; } 
        }


    }
}