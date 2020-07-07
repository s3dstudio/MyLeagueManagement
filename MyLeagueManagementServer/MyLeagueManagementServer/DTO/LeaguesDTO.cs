using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class LeaguesDTO
    {
        public string _Key { get; set; }
        public string ID { get; set; }
        public string LeagueName { get; set; }  
        public string Logo { get; set; }
        public string NumClub { get; set; }
        public string Nationality { get; set; }
    }
}
