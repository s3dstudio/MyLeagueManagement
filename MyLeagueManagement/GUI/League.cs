using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Data;

namespace GUI
{
    public class League : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string leaguename;
        public string LeagueName
        {
            get { return this.leaguename; }
            set
            {
                if (this.leaguename != value)
                {
                    this.leaguename = value;
                    this.NotifyPropertyChanged("LeagueName");
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

        private string coverimg;
        public string CoverImg
        {
            get { return this.coverimg; }
            set
            {
                if (this.coverimg != value)
                {
                    this.coverimg = value;
                    this.NotifyPropertyChanged("CoverImg");
                }
            }
        }

        private int numclub;
        public int NumClub
        {
            get { return this.numclub; }
            set
            {
                if (this.numclub != value)
                {
                    this.numclub = value;
                    this.NotifyPropertyChanged("NumClub");
                }
            }
        }

        private ArrayList listclub;
        public ArrayList ListClub
        {
            get { return this.listclub; }
            set
            {
                if (this.listclub != value)
                {
                    this.listclub = value;
                    this.NotifyPropertyChanged("ListClub");
                }
            }
        }

        private string nationality;
        public string Nationality
        {
            get { return this.nationality; }
            set
            {
                if (this.nationality != value)
                {
                    this.nationality = value;
                    this.NotifyPropertyChanged("Nationality");
                }
            }
        }

        private bool isactive;
        public bool IsActive
        {
            get { return this.isactive; }
            set
            {
                if (this.isactive != value)
                {
                    this.isactive = value;
                    this.NotifyPropertyChanged("IsActive");
                }
            }
        }

        private Setting rule;
        public Setting Rule
        {
            get { return this.rule; }
            set
            {
                if (this.rule != value)
                {
                    this.rule = value;
                    this.NotifyPropertyChanged("Rule");
                }
            }
        }

        private ArrayList allmatch;
        public ArrayList AllMatch
        {
            get { return this.allmatch; }
            set
            {
                if (this.allmatch != value)
                {
                    this.allmatch = value;
                    this.NotifyPropertyChanged("ListClub");
                }
            }
        }

        

        public League(string leaguename, string logo, string nationality)
        {
            this.NumClub = 6;
            this.CoverImg = "zozd74mt2nl41.jpg";
            this.LeagueName = leaguename;
            this.Logo = logo;
            this.Nationality = nationality;
            this.Rule = new Setting();
            this.ListClub = new ArrayList();
            this.IsActive = false;
        }

        public League()
        {

        }

        public ArrayList GetRoundMatch(ArrayList AllClubs)
        {
            int n = AllClubs.Count;
            ArrayList Round1 = new ArrayList();
            ArrayList Round2 = new ArrayList();
            if (n > 0)
            {

                foreach (Club i in AllClubs)
                {
                    foreach (Club j in AllClubs)
                    {
                        if (AllClubs.IndexOf(i) != AllClubs.IndexOf(j))
                        {

                            if (AllClubs.IndexOf(i) > AllClubs.IndexOf(j))
                            {
                                Round1.Add(new Match(i, j));
                            }
                            else if (AllClubs.IndexOf(i) < AllClubs.IndexOf(j))
                                Round2.Add(new Match(i, j));
                        }

                    }
                }
            }
            return new ArrayList(2) { Round1, Round2 };
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
