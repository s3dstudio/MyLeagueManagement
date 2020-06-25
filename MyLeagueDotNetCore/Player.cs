using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Player : INotifyPropertyChanged
    {
        private string playername;
        public string PlayerName
        {
            get { return this.playername; }
            set
            {
                if (this.playername != value)
                {
                    this.playername = value;
                    this.NotifyPropertyChanged("PlayerName");
                }
            }
        }
        private int number;
        public int Number
        {
            get { return this.number; }
            set
            {
                if (this.number != value)
                {
                    this.number = value;
                    this.NotifyPropertyChanged("Number");
                }
            }
        }
        private DateTime dob;
        public DateTime DoB
        {
            get { return this.dob; }
            set
            {
                if (this.dob != value)
                {
                    this.dob = value;
                    this.NotifyPropertyChanged("DoB");
                }
            }
        }

        private string position;
        public string Position
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
        private string image;
        public string Image
        {
            get { return this.image; }
            set
            {
                if (this.image != value)
                {
                    this.image = value;
                    this.NotifyPropertyChanged("Image");
                }
            }
        }
        private string club;
        public string Club
        {
            get { return this.club; }
            set
            {
                if (this.club != value)
                {
                    this.club = value;
                    this.NotifyPropertyChanged("Club");
                }
            }
        }
        private int allgoal;
        public int AllGoal
        {
            get { return this.allgoal; }
            set
            {
                if (this.allgoal != value)
                {
                    this.allgoal = value;
                    this.NotifyPropertyChanged("AllGoal");
                }
            }
        }

        public Player(string playername, int number, DateTime dob, string position, string nationality, string image, string club, int allgoal)
        {
            this.PlayerName = playername;
            this.Number = number;
            this.DoB = dob;
            this.Position = position;
            this.Nationality = nationality;
            this.Image = image;
            this.Club = club;
            this.AllGoal = allgoal;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}


