using DTO;
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
    /// Interaction logic for LEAGUE.xaml
    /// </summary>
    public partial class UC_LEAGUE : UserControl, INotifyPropertyChanged
    {
        private League selectedleague;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public League SelectedLeague
        {
            get { return this.selectedleague; }
            set
            {
                if (this.selectedleague != value)
                {
                    this.selectedleague = value;
                    this.NotifyPropertyChanged("SelectedLeague");
                }
            }
        }
        public UC_LEAGUE(League l)
        {
            InitializeComponent();
            this.SelectedLeague = l;
            

        }
        public ArrayList GetListClubByLeagueKey(string LeagueKey)
        {
            ArrayList arr = new ArrayList();
            string jsonString = Client.Instance.Get("api/clubs");
            var Data = DTO.ClubsDTO.FromJson(jsonString);
            foreach (KeyValuePair<string, ClubsDTO> value in Data)
            {
                if (value.Value.LeagueKey == LeagueKey)
                    arr.Add(value);
            }
            return arr;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (140 * index), 0, 0, 0);


            switch (index)
            {
                case 0:
                    GridMain.Children.Clear();
                    //GridMain.Background = Brushes.Aquamarine;
                    break;
                case 1:
                    //GridMain.Background = Brushes.White;
                    GridMain.Children.Clear();
                    UC_ALLCLUB a = new UC_ALLCLUB(GetListClubByLeagueKey(SelectedLeague._Key));
                    GridMain.Children.Add(a);

                    break;
                case 2:
                    GridMain.Children.Clear();
                    UC_FIXTURES f = new UC_FIXTURES(SelectedLeague.AllMatch);
                   GridMain.Children.Add(f);
                    //GridMain.Background = Brushes.CadetBlue;
                    break;
                case 3:
                    GridMain.Children.Clear();
                    UC_RESULTS r = new UC_RESULTS();
                    GridMain.Children.Add(r);
                    //GridMain.Background = Brushes.DarkBlue;
                    break;
                case 4:
                    GridMain.Children.Clear();
                    UC_ALLPLAYER p = new UC_ALLPLAYER();
                    GridMain.Children.Add(p);
                    //GridMain.Background = Brushes.Firebrick;
                    break;
                case 5:
                    GridMain.Background = Brushes.White;
                    GridMain.Children.Clear();
                    UC_TABLES t = new UC_TABLES();
                    GridMain.Children.Add(t);
                    break;
                case 6:
                    GridMain.Children.Clear();
                    ExPlayer h = new ExPlayer();
                    GridMain.Children.Add(h);
                    break;
            }
        }

        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
