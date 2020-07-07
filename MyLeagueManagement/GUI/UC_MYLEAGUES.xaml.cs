using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UC_MYLEAGUES.xaml
    /// </summary>
    public partial class UC_MYLEAGUES : UserControl, INotifyPropertyChanged
    {
        private ArrayList leaguelist;
        public ArrayList LeagueList
        {
            get { return this.leaguelist; }
            set
            {
                if (this.leaguelist != value)
                {
                    this.leaguelist = value;
                    this.NotifyPropertyChanged("LeagueList");
                }
            }
        }
        public UC_MYLEAGUES()
        {
            InitializeComponent();
            League newleague = new League("This is league name nha", "pre.png", "Nationality tao truyền vào Laos");
            UC_NEWLEAGUE l = new UC_NEWLEAGUE(newleague);
            MainGrid.Children.Add(l);
            LeagueList = GetLeague();
            if (LeagueList.Count > 0)
            {
                LeagueListBox.ItemsSource = LeagueList;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ArrayList GetLeague()
        {
            return new ArrayList
            {
                new League("Premier League", "pre.png", "England"),
                new League("La Liga", "laliga.jpg", "Spain"),
                new League("Series A", "seriesa.jpg", "Italia"),
                new League("Bundesliga", "bun.png","Germany"),
                new League("La Liga", "laliga.jpg", "Spain"),
                new League("Series A", "seriesa.jpg", "Italia"),
                new League("Bundesliga", "bun.png","Germany")
            };
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
