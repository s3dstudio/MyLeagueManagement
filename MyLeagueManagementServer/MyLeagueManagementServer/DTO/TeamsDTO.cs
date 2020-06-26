using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class TeamsDTO
    {
        public string _Key { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string HomeGround { get; set; }
        public string NoPlayer { get; set; }

    }
}
