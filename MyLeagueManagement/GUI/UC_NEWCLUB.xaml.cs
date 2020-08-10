using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Controls;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UC_NEWCLUB.xaml
    /// </summary>
    public partial class UC_NEWCLUB : UserControl, INotifyPropertyChanged
    {

        private Player tempplayer;
        public Player TempPlayer
        {
            get { return this.tempplayer; }
            set
            {
                if (this.tempplayer != value)
                {
                    this.tempplayer = value;
                    this.NotifyPropertyChanged("TempPlayer");
                }
            }
        }

        private Club myclub;
        public Club MyClub
        {
            get { return this.myclub; }
            set
            {
                if (this.myclub != value)
                {
                    this.myclub = value;
                    this.NotifyPropertyChanged("MyClub");
                }
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UC_NEWCLUB(Club abc)
        {

           
            this.MyClub = abc;
            //MyClub.ListPlayer = GetPlayer();
            InitializeComponent();
            //this.MyClub.ListPlayer = GetPlayer();
            Card_Player.Visibility = Visibility.Collapsed;
            Card_General.Visibility = Visibility.Visible;
            this.DataContext = MyClub;
            
            //if(this.MyClub.ListPlayer.Count >= 0)
            //{
            ListPlayer.ItemsSource = MyClub.ListPlayer;
            //}
            ListPlayer.SelectedItem = null;
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(20 + (100 * index), 0, 0, 0);


            switch (index)
            {
                case 0:
                    Card_Player.Visibility = Visibility.Collapsed;
                    Card_General.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Card_General.Visibility = Visibility.Collapsed;
                    Card_Player.Visibility = Visibility.Visible;
                    this.Btn_Modify.IsEnabled = false;
                    this.Btn_Remove.IsEnabled = false;
                    this.Btn_Add.IsEnabled = true;
                    break;
            }
        }

        private void Btn_Edit_Cover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            string ClubCover = null;
            ClubCover = openFileDialog.FileName;
            if (string.Compare(ClubCover, "", true) != 0)
            {
                Img_Club_Cover.Source = new BitmapImage(new Uri(@ClubCover, UriKind.RelativeOrAbsolute));
            }
        }

        private void Btn_AddLogoClub_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            string ClubLogo = null;
            ClubLogo = openFileDialog.FileName;
            if (string.Compare(ClubLogo, "", true) != 0)
            {
                Img_Club_Logo.Source = new BitmapImage(new Uri(@ClubLogo, UriKind.RelativeOrAbsolute));
              //  MyClub.Logo = ClubLogo;
            }
        }

        private ArrayList GetPlayer()
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
            return new ArrayList()
            {
            //new Player("Mohamed Salah",11,tempDate, "Forward", "Egypt","Sala.png","Liverpool",21),
            //new Player("Fabinho", 6,tempDate, "Midfielder", "Brazil", "Fabinho.png", "Liverpool", 1),
            //new Player("Sadio Mane", 5,tempDate, "Midfielder", "Senegal", "Mane.png", "Liverpool", 14),
            //new Player("Roberto Firmino", 9,tempDate, "Forward", "Brazil", "Firmino.png", "Liverpool", 18),
            ////new Player("Alisson", 1,tempDate, "Goal Keeper", "Brazil", "Alisson.png", "Liverpool", 0),
            ////new Player("Virgil van Dijk", 4,tempDate, "Defender", "Netherlands", "Vandijk.png", "Liverpool", 3),
            ////new Player("Paul Pogba", 6,tempDate, "Midfielder", "France", "Pogba.png", "Manchester United", 4),
            ////new Player("Harry Maguire", 4,tempDate, "Defender", "England", "Maguire.png", "Manchester United", 1),
            ////new Player("David de Gea", 1,tempDate, "Goal Keeper", "Spain", "David.png", "Manchester United", 0),
            ////new Player("Bruno Fernandes", 18,tempDate, "Midfielder", "Portugal", "Bruno.png", "Manchester United", 7),
            ////new Player("Jesse Lingard", 14,tempDate, "Midfielder", "England", "Lingard.png", "Manchester United", 1),
            ////new Player("Daniel James", 21,tempDate, "Midfielder", "Wales", "James.png", "Manchester United", 6),
            //new Player("Marcus Rashford", 9,tempDate, "Forward", "England", "Rashford.png", "Manchester United", 15)
            };
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (ListPlayer.SelectedItem != null)
            {
                MyClub.ListPlayer.Remove(ListPlayer.SelectedItem as Player);
                CollectionViewSource.GetDefaultView(ListPlayer.ItemsSource).Refresh();
            }
        }

        private void ListPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListPlayer.SelectedItem == null)
            {
                this.Btn_Modify.IsEnabled = false;
                this.Btn_Remove.IsEnabled = false;
                this.Btn_Add.IsEnabled = true;
            }
            else
            {
                this.Btn_Modify.IsEnabled = true;
                this.Btn_Remove.IsEnabled = true;
                this.Btn_Add.IsEnabled = false;
            }
        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {                  
            int i = MyClub.ListPlayer.IndexOf(ListPlayer.SelectedItem as Player);
            this.Diaglog_Detail_Player.DataContext = MyClub.ListPlayer[i];
        }

        private void Btn_ShowListPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Edit_Player_Img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            string PlayerImg = null;
            PlayerImg = openFileDialog.FileName;
            if (string.Compare(PlayerImg, "", true) != 0)
            {
                Player_Img.Source = new BitmapImage(new Uri(@PlayerImg, UriKind.RelativeOrAbsolute));
            }
        }

        private void Btn_Confirm_Player_Click(object sender, RoutedEventArgs e)
        {
            
            
                BindingExpression playername = Txb_PlayerName.GetBindingExpression(TextBox.TextProperty);
                playername.UpdateSource();
                BindingExpression num = Txb_Number.GetBindingExpression(TextBox.TextProperty);
                num.UpdateSource();
                BindingExpression dob = Txb_DoB.GetBindingExpression(DatePicker.TextProperty);
                dob.UpdateSource();
                BindingExpression na = Txb_Nationality.GetBindingExpression(TextBox.TextProperty);
                na.UpdateSource();
                BindingExpression club = Txb_Club.GetBindingExpression(TextBox.TextProperty);
                club.UpdateSource();
                BindingExpression pos = Cbb_Position.GetBindingExpression(ComboBox.TextProperty);
                pos.UpdateSource();
                BindingExpression im = Player_Img.GetBindingExpression(Image.SourceProperty);
                im.UpdateSource();
            // Neu khong co Player nao duoc chon => Add Player 
                if (ListPlayer.SelectedItem == null)
                {
                this.MyClub.ListPlayer.Add(TempPlayer);
                }
                ListPlayer.ItemsSource = MyClub.ListPlayer;
                CollectionViewSource.GetDefaultView(ListPlayer.ItemsSource).Refresh();
                ListPlayer.SelectedItem = null;
                this.Diaglog_Detail_Player.DataContext = null;
        }

        private void Btn_Cancel_Player_Click(object sender, RoutedEventArgs e)
        {
            ListPlayer.SelectedItem = null;
            CollectionViewSource.GetDefaultView(ListPlayer.ItemsSource).Refresh();
            this.Diaglog_Detail_Player.DataContext = null;
        }

        // add new player
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            DateTime tempDate = new DateTime(2000, 01, 01);
            TempPlayer = new Player("Player Name", 1, tempDate, "Forward", "Egypt", "Photo-Missing.png", MyClub.ClubName, MyClub.Logo, 0);
            this.Diaglog_Detail_Player.DataContext = TempPlayer;
        }
    }
}

