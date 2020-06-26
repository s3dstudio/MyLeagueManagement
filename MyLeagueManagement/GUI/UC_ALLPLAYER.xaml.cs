using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
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
using System.Collections;


namespace GUI
{
    /// <summary>
    /// Interaction logic for UC_ALLPLAYER.xaml
    /// </summary>
    public partial class UC_ALLPLAYER : UserControl, INotifyPropertyChanged
    {
        ArrayList MyListPlayer = new ArrayList();

        public event PropertyChangedEventHandler PropertyChanged;

        public UC_ALLPLAYER()
        {
            InitializeComponent();
            MyListPlayer = GetPlayer();
            //var MyListPlayer = GetPlayer();
            if(MyListPlayer.Count >0)
            {
                ListPlayer.ItemsSource = MyListPlayer;
                
            }

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListPlayer.ItemsSource);
            view.Filter = PlayerFilter;
           
        }

        private ArrayList GetPlayer()
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
            return new ArrayList()
            {             
            new Player("Mohamed Salah",11,tempDate, "Forward", "Egypt","Sala.png","Liverpool",21),
            new Player("Fabinho", 6,tempDate, "Midfielder", "Brazil", "Fabinho.png", "Liverpool", 1),
            new Player("Sadio Mane", 5,tempDate, "Midfielder", "Senegal", "Mane.png", "Liverpool", 14),
            new Player("Roberto Firmino", 9,tempDate, "Forward", "Brazil", "Firmino.png", "Liverpool", 18),
            new Player("Alisson", 1,tempDate, "Goal Keeper", "Brazil", "Alisson.png", "Liverpool", 0),
            new Player("Virgil van Dijk", 4,tempDate, "Defender", "Netherlands", "Vandijk.png", "Liverpool", 3),
            new Player("Paul Pogba", 6,tempDate, "Midfielder", "France", "Pogba.png", "Manchester United", 4),
            new Player("Harry Maguire", 4,tempDate, "Defender", "England", "Maguire.png", "Manchester United", 1),
            new Player("David de Gea", 1,tempDate, "Goal Keeper", "Spain", "David.png", "Manchester United", 0),
            new Player("Bruno Fernandes", 18,tempDate, "Midfielder", "Portugal", "Bruno.png", "Manchester United", 7),
            new Player("Jesse Lingard", 14,tempDate, "Midfielder", "England", "Lingard.png", "Manchester United", 1),
            new Player("Daniel James", 21,tempDate, "Midfielder", "Wales", "James.png", "Manchester United", 6),
            new Player("Marcus Rashford", 9,tempDate, "Forward", "England", "Rashford.png", "Manchester United", 15)
            };
        }

        private bool PlayerFilter(object item)
        {
            if (String.IsNullOrEmpty(SearchTxb.Text))
                return true;
            else
                return ((item as Player).PlayerName.IndexOf(SearchTxb.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void SearchTxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListPlayer.ItemsSource).Refresh();
        }



        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
           if(ListPlayer.SelectedItem != null)
            {
                MyListPlayer.Remove(ListPlayer.SelectedItem as Player);
                CollectionViewSource.GetDefaultView(ListPlayer.ItemsSource).Refresh();
            }
        }
    }
}

