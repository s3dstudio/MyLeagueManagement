using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class LeaguesDTO
    {
        public string _Key { get; set; }
        public string LeagueName { get; set; }  
        public string Logo { get; set; }
        public string NumClub { get; set; }
        public string Nationality { get; set; }
        public string CoverImg { get; set; }
        public string IsActive { get; set; }
        public string RuleKey { get; set; }
    }
}
