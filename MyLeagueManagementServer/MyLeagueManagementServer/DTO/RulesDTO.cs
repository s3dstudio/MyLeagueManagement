using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class RulesDTO
    {
        public string _Key { get; set; }
        public string MinAge {get;set;}
        public string MaxAge { get; set; }
        public string MaxSquadSize { get; set; }
        public string MinSquadSize { get; set; }
        public string MaxForeign { get; set; }
        public string WinPoint { get; set; }
        public string LossPoint { get; set; }
        public string DrawPoint { get; set; }
        public string Priority { get; set; }
        public string Stoppage { get; set; }
        public string MaxStoppageTime { get; set; }
    }
}
