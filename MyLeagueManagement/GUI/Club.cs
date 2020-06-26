using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Club
    {
        public int Position { get; set; }
        public string ClubName { get; set; }
        public string Stadium { get; set; }
        public string Logo { get; set; }
        public string Manager { get; set; }
        public int Plays { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
        public int GF { get; set; }
        public int GA { get; set; }
        public int GD { get; set; }
        public string BackGround { get; set; }
        public string CoverImage { get; set; }

        public Club(int position, string clubname, string stadium, string logo, string manager, int plays, int won, int drawn, int lost, int points, int gf, int ga, int gd, string background, string coverimage)
        {
            Position = position;
            ClubName = clubname;
            Stadium = stadium;
            Logo = logo;
            Manager = manager;
            Plays = plays;
            Won = won;
            Drawn = drawn;
            Lost = lost;
            Points = points;
            GF = gf;
            GA = ga;
            GD = gd;
            BackGround = background;
            CoverImage = coverimage;
        }

    }

}
