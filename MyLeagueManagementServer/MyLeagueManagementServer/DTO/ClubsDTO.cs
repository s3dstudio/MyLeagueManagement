using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeagueManagementServer.DTO
{
    public class ClubsDTO
    {
        public string _Key { get; set; }
        public string LeagueKey { get; set; }
        public string ID { get; set; }
        public string Position { get; set; }

        public string ClubName { get; set; }

        public string Stadium { get; set; }

        public string Logo { get; set; }

        public string Manager { get; set; }

        public string Plays { get; set; }

        public string Won { get; set; }

        public string Drawn { get; set; }

        public string Lost { get; set; }

        public string Points { get; set; }

        public string GF { get; set; }

        public string GA { get; set; }

        public string GD { get; set; }

        public string BackGround { get; set; }

        public string CoverImage { get; set; }
    }
}
