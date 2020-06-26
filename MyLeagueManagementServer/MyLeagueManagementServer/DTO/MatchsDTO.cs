using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class MatchsDTO
    {
        public string _Key { get; set; }
        public string ID { get; set; }
        public string ID_Team1 { get; set; }
        public string ID_Team2 { get; set; }
        public string Stadium { get; set; }
        public string MatchResult_Key { get; set; }
    }
}
