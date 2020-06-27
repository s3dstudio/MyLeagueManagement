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
        public string Number { get; set; }
        public string DoB { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public string Image { get; set; }
        public string Key_Type { get; set; }
        public string AllGoal { get; set; }
        public string Teams_Key { get; set; }
    }
}
