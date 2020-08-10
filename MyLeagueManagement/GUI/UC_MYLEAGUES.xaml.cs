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
        private League templeague;
        public League TempLeague
        {
            get { return this.templeague; }
            set
            {
                if (this.templeague != value)
                {
                    this.templeague = value;
                    this.NotifyPropertyChanged("TempLeague");
                }
            }
        }

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
            this.templeague = new League("", "Pree.png", "");
            UC_NEWLEAGUE l = new UC_NEWLEAGUE(templeague);
            MainGrid.Children.Add(l);
            LeagueList = GetLeague();
            LeagueListBox.ItemsSource = LeagueList;

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

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            switch (index)
            {
                case 0:
                    ((Grid)this.Parent).Children.Remove(this);
                    
                    break;
                case 1:
                    if(this.TempLeague.IsActive == true)
                    {
                        LeagueList.Add(TempLeague);
                        
                       
                        TempLeague.AllMatch = new ArrayList(TempLeague.GetRoundMatch(TempLeague.ListClub));
                    }
                    this.templeague = new League("", "pre.png", "");
                    UC_NEWLEAGUE l = new UC_NEWLEAGUE(templeague);
                    MainGrid.Children.Add(l);
                    CollectionViewSource.GetDefaultView(LeagueListBox.ItemsSource).Refresh();
                    
                    break;
                case 2:
                    ((Grid)this.Parent).Children.Remove(this);
                    

                    break;
            }
        }

        private void LeagueListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LeagueListBox.ItemsSource).Refresh();
            int i = LeagueList.IndexOf(LeagueListBox.SelectedItem as League);
            UC_LEAGUE Selected = new UC_LEAGUE(LeagueList[i] as League);
            //LeagueListBox.SelectedItem = null;
            //MainGrid.Children.Clear();
            // MainGrid.Children.Add(Selected);
           // ((Grid)this.Parent).Children.Clear();
          ((Grid)this.Parent).Children.Add(Selected);

        }
    }
}
