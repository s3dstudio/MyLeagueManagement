using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Club : INotifyCollectionChanged
    {
        private int position;
        public int Position
        {
            get { return this.position; }
            set
            {
                if (this.position != value)
                {
                    this.position = value;
                    this.NotifyPropertyChanged("Position");
                }
            }
        }

        private string clubname;
        public string ClubName
        {
            get { return this.clubname; }
            set
            {
                if (this.clubname != value)
                {
                    this.clubname = value;
                    this.NotifyPropertyChanged("ClubName");
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

        private string logo;
        public string Logo
        {
            get { return this.logo; }
            set
            {
                if (this.logo != value)
                {
                    this.logo = value;
                    this.NotifyPropertyChanged("Logo");
                }
            }
        }

        private string manager;
        public string Manager
        {
            get { return this.manager; }
            set
            {
                if (this.manager != value)
                {
                    this.manager = value;
                    this.NotifyPropertyChanged("Manager");
                }
            }
        }

        private int plays;
        public int Plays
        {
            get { return this.plays; }
            set
            {
                if (this.plays != value)
                {
                    this.plays = value;
                    this.NotifyPropertyChanged("Plays");
                }
            }
        }

        private int won;
        public int Won
        {
            get { return this.won; }
            set
            {
                if (this.won != value)
                {
                    this.won = value;
                    this.NotifyPropertyChanged("Won");
                }
            }
        }

        private int drawn;
        public int Drawn
        {
            get { return this.drawn; }
            set
            {
                if (this.drawn != value)
                {
                    this.drawn = value;
                    this.NotifyPropertyChanged("Drawn");
                }
            }
        }

        private int lost;
        public int Lost
        {
            get { return this.lost; }
            set
            {
                if (this.lost != value)
                {
                    this.lost = value;
                    this.NotifyPropertyChanged("Lost");
                }
            }
        }

        private int points;
        public int Points
        {
            get { return this.points; }
            set
            {
                if (this.points != value)
                {
                    this.points = value;
                    this.NotifyPropertyChanged("Points");
                }
            }
        }

        private int gf;
        public int GF
        {
            get { return this.gf; }
            set
            {
                if (this.gf != value)
                {
                    this.gf = value;
                    this.NotifyPropertyChanged("GF");
                }
            }
        }

        private int ga;
        public int GA
        {
            get { return this.ga; }
            set
            {
                if (this.ga != value)
                {
                    this.ga = value;
                    this.NotifyPropertyChanged("GA");
                }
            }
        }

        private int gd;
        public int GD
        {
            get { return this.gd; }
            set
            {
                if (this.gd != value)
                {
                    this.gd = value;
                    this.NotifyPropertyChanged("GD");
                }
            }
        }

        private string background;
        public string BackGround
        {
            get { return this.background; }
            set
            {
                if (this.background != value)
                {
                    this.background = value;
                    this.NotifyPropertyChanged("BackGround");
                }
            }
        }

        private string coverimage;
        public string CoverImage
        {
            get { return this.coverimage; }
            set
            {
                if (this.coverimage != value)
                {
                    this.coverimage = value;
                    this.NotifyPropertyChanged("CoverImage");
                }
            }
        }

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

        public Club()
        { }

        public Club(string coverimage, string logo)
        {
            this.Logo = logo;
            this.CoverImage = coverimage;
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
