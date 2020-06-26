using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class PlayersDTO
    {
        public string _Key { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Birth { get; set; }
        public string Key_Type { get; set; }
        public string Goals { get; set; }
        public string Teams_Key { get; set; }
    }
}
