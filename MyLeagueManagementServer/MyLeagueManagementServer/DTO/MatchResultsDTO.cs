using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class MatchResultsDTO
    {
        public string _Key { get; set; }
        public string ID { get; set; }
        public string Goals_Team1 { get; set; }
        public string Goals_Team2 { get; set; }
        public string DetailMatchResult_Key { get; set; }
    }
}
