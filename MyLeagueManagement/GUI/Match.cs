using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Match
    {
        public Club Home { get; set; }
        public string HomeName { get; set; }
        public string HomeLogo { get; set; }
        public int GoalHome { get; set; }
        public Club Away { get; set; }
        public string AwayName { get; set; }
        public int GoalAway { get; set; }
        public string AwayLogo { get; set; }
        public string Stadium { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Match(Club home, int goalhome, Club away, int goalaway, string stadium, string date, string time)
        {
            this.Home = home;
            this.GoalAway = goalaway;
            this.Away = away;
            this.GoalHome = goalhome;
            this.Stadium = stadium;
            this.Time = time;
            this.Date = date;
        }

        public Match(Club home, Club away)
        {
            this.Home = home;
            this.Away = away;
            this.HomeName = this.Home.ClubName;
            this.AwayName = this.Away.ClubName;
            this.Stadium = this.Home.Stadium;
            this.HomeLogo = this.Home.Logo;
            this.AwayLogo = this.Away.Logo;
        }
    }
}
