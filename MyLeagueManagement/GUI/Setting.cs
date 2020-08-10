using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Setting : INotifyPropertyChanged
    {
        private int minage;
        public int MinAge
        {
            get { return this.minage; }
            set
            {
                if (this.minage != value)
                {
                    this.minage = value;
                    this.NotifyPropertyChanged("MinAge");

                }
            }
        }

        private int maxage;
        public int MaxAge
        {
            get { return this.maxage; }
            set
            {
                if (this.maxage != value)
                {
                    this.maxage = value;
                    this.NotifyPropertyChanged("MaxAge");

                }
            }
        }

        private int minsquadsize;
        public int MinSquadSize
        {
            get { return this.minsquadsize; }
            set
            {
                if (this.minsquadsize != value)
                {
                    this.minsquadsize = value;
                    this.NotifyPropertyChanged("MinSquadSize");

                }
            }
        }

        private int maxsquadsize;
        public int MaxSquadSize
        {
            get { return this.maxsquadsize; }
            set
            {
                if (this.maxsquadsize != value)
                {
                    this.maxsquadsize = value;
                    this.NotifyPropertyChanged("MaxSquadSize");

                }
            }
        }

        private int maxforeign;
        public int MaxForeign
        {
            get { return this.maxforeign; }
            set
            {
                if (this.maxforeign != value)
                {
                    this.maxforeign = value;
                    this.NotifyPropertyChanged("MaxForeign");

                }
            }
        }

        private int maxstoppagetime;
        public int MaxStoppageTime
        {
            get { return this.maxstoppagetime; }
            set
            {
                if (this.maxstoppagetime != value)
                {
                    this.maxstoppagetime = value;
                    this.NotifyPropertyChanged("MaxStoppageTime");

                }
            }
        }

        private int winpoint;
        public int  WinPoint

        {
            get { return this.winpoint; }
            set
            {
                if (this.winpoint != value)
                {
                    this.winpoint = value;
                    this.NotifyPropertyChanged("WinPoint");

                }
            }
        }

        private int losspoint;
        public int LossPoint

        {
            get { return this.losspoint; }
            set
            {
                if (this.losspoint != value)
                {
                    this.losspoint = value;
                    this.NotifyPropertyChanged("LossPoint");

                }
            }
        }

        private int drawpoint;
        public int DrawPoint

        {
            get { return this.drawpoint; }
            set
            {
                if (this.drawpoint != value)
                {
                    this.drawpoint = value;
                    this.NotifyPropertyChanged("DrawPoint");
                }
            }
        }


        private string priority;
        public string Priority

        {
            get { return this.priority; }
            set
            {
                if (this.priority != value)
                {
                    this.priority = value;
                    this.NotifyPropertyChanged("Priority");
                }
            }
        }

        private int stoppage;
        public int Stoppage

        {
            get { return this.stoppage; }
            set
            {
                if (this.stoppage != value)
                {
                    this.stoppage = value;
                    this.NotifyPropertyChanged("Stoppage");
                }
            }
        }

        public Setting()
        {
            this.MinAge = 16;
            this.MaxAge = 36;
            this.MaxSquadSize = 24;
            this.MinSquadSize = 16;
            this.MaxForeign = 3;
            this.WinPoint = 3;
            this.LossPoint = 0;
            this.DrawPoint = 1;
            this.Priority = "Point - Goal Diffrence - Away Goals - Head to Head";
            this.Stoppage = 7;
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
