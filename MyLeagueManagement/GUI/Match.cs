using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Match : INotifyPropertyChanged
    {
        
        private Club home;
        public Club Home
        {
            get { return this.home; }
            set
            {
                if (this.home != value)
                {
                    this.home = value;
                    this.NotifyPropertyChanged("Home");

                }
            }
        }
        private string homename;
        public string HomeName
        {
            get { return this.homename; }
            set
            {
                if (this.homename != value)
                {
                    this.homename = value;
                    this.NotifyPropertyChanged("HomeName");

                }
            }
        }
        private string homelogo;
        public string HomeLogo
        {
            get { return this.homelogo; }
            set
            {
                if (this.homelogo != value)
                {
                    this.homelogo = value;
                    this.NotifyPropertyChanged("HomeLogo");

                }
            }
        }
        private int goalhome;
        public int GoalHome
        {
            get { return this.goalhome; }
            set
            {
                if (this.goalhome != value)
                {
                    this.goalhome = value;
                    this.NotifyPropertyChanged("GoalHome");

                }
            }
        }
        private Club away;
        public Club Away
        {
            get { return this.away; }
            set
            {
                if (this.away != value)
                {
                    this.away = value;
                    this.NotifyPropertyChanged("Away");

                }
            }
        }

        private string awayname;
        public string AwayName
        {
            get { return this.awayname; }
            set
            {
                if (this.awayname != value)
                {
                    this.awayname = value;
                    this.NotifyPropertyChanged("AwayName");

                }
            }
        }

        private int goalaway;
        public int GoalAway
        {
            get { return this.goalaway; }
            set
            {
                if (this.goalaway != value)
                {
                    this.goalaway = value;
                    this.NotifyPropertyChanged("GoalAway");

                }
            }
        }

        private string awaylogo;
        public string AwayLogo
        {
            get { return this.awaylogo; }
            set
            {
                if (this.awaylogo != value)
                {
                    this.awaylogo = value;
                    this.NotifyPropertyChanged("AwayLogo");

                }
            }
        }

        private string stadium;
        public string Stadium
        {
            get { return this.stadium; }
            set
            {
                if (this.stadium != value)
                {
                    this.stadium = value;
                    this.NotifyPropertyChanged("Stadium");

                }
            }
        }

        private string date;
        public string Date
        {
            get { return this.date; }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.NotifyPropertyChanged("Date");

                }
            }
        }

        private string time;
        public string Time
        {
            get { return this.time; }
            set
            {
                if (this.time != value)
                {
                    this.time = value;
                    this.NotifyPropertyChanged("Time");

                }
            }
        }




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
            this.GoalAway = -1;
            this.GoalAway = -1;
            this.Date = DateTime.Now.ToString();
            this.Time = "00:00";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
