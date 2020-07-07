using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;

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

       

        public League(string leaguename, string logo, string nationality)
        {
            this.LeagueName = leaguename;
            this.Logo = logo;
            this.Nationality = nationality;
        }

        public League()
        {

        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
