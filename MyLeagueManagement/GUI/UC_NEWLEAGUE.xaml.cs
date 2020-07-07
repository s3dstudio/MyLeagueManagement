using Microsoft.Win32;
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
    /// Interaction logic for UC_NEWLEAGUE.xaml
    /// </summary>
    public partial class UC_NEWLEAGUE : UserControl, INotifyPropertyChanged
    {
        private string tempcoverclub;
        public string TempCoverClub
        {
            get { return this.tempcoverclub; }
            set
            {
                if (this.tempcoverclub != value)
                {
                    this.tempcoverclub = value;
                    this.NotifyPropertyChanged("TempCoverClub");
                }
            }
        }
        private string templogoclub;
        public string TempLogoClub
        {
            get { return this.templogoclub; }
            set
            {
                if (this.templogoclub != value)
                {
                    this.templogoclub = value;
                    this.NotifyPropertyChanged("TempLogoClub");
                }
            }
        }
        Club tempclub;
        private League mynewleague;
        public League MyNewLeague
        {
            get { return this.mynewleague; }
            set
            {
                if (this.mynewleague != value)
                {
                    this.mynewleague = value;
                    this.NotifyPropertyChanged("MyNewLeague");
                }
            }
        }

        public string Logo;
        public string Cover;

        public event PropertyChangedEventHandler PropertyChanged;

        public UC_NEWLEAGUE(League l)
        {
            // khúc này t k biết t viết cái gì luôn !!!??? nói chung là truyền 1 cái League từ cái UC_MYLEAGUE qua rồi cho nó bằng cái MyNewLeague
            // xong cho thằng MyNewLeague xử lí

            InitializeComponent();
            var listclub = GetClubs();
            this.DataContext = l;
            l.ListClub = listclub;
            this.MyNewLeague = l;
            Grid_Info.Visibility = Visibility.Visible;
            Grid_Clubs.Visibility = Visibility.Collapsed;
            if (MyNewLeague.ListClub.Count > 0)
            {
                Club_List_Box.ItemsSource = MyNewLeague.ListClub;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(60 + (140 * index), 0, 0, 0);


            switch (index)
            {
                case 0:
                    Grid_Info.Visibility = Visibility.Visible;
                    Grid_Clubs.Visibility = Visibility.Collapsed;
                    Scrollv.ScrollToVerticalOffset(340);
                    // LeagueContent.Children.Clear();
                    //UC_ADD_LEAGUE_INFO a = new UC_ADD_LEAGUE_INFO();
                    //LeagueContent.Children.Add(a);
                    break;
                case 1:
                    Grid_Info.Visibility = Visibility.Collapsed;
                    Grid_Clubs.Visibility = Visibility.Collapsed;
                    //LeagueContent.Children.Clear();
                    //Grid_Info.Visibility = Visibility.Collapsed;
                    //Grid_Clubs.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Scrollv.ScrollToVerticalOffset(340);
                    Grid_Info.Visibility = Visibility.Collapsed;
                    Grid_Clubs.Visibility = Visibility.Visible;
                    if (this.MyNewLeague.ListClub.Count > 0)
                    {
                        Card_ALLClubs.Visibility = Visibility.Visible;
                        Grid_Add_New_Club.Children.Clear();
                    }
                    else
                    {
                        Card_ALLClubs.Visibility = Visibility.Collapsed;
                        //UC_NEWCLUB newclub = new UC_NEWCLUB();
                        // Grid_Add_New_Club.Children.Clear();
                        // Grid_Add_New_Club.Children.Add(newclub);
                    }

                    // LeagueContent.Children.Clear();
                    //UC_ADD_CLUB_TO_LEAGUE b = new UC_ADD_CLUB_TO_LEAGUE();
                    //LeagueContent.Children.Add(b);
                    break;

            }
        }

        private void Btn_AddLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            Logo = openFileDialog.FileName;
            if (string.Compare(Logo, "", true) != 0)
            {
                Img_Logo.ImageSource = new BitmapImage(new Uri(@Logo, UriKind.RelativeOrAbsolute));
            }
        }

        private void Btn_ShowListClub_Click(object sender, RoutedEventArgs e)
        {
            Card_ALLClubs.Visibility = Visibility.Visible;
            Grid_Add_New_Club.Children.Clear();


        }

        // private void Btn_Add_Click(object sender, RoutedEventArgs e)
        // {
        // Card_ALLClubs.Visibility = Visibility.Collapsed;
        // UC_NEWCLUB newclub = new UC_NEWCLUB();
        // Grid_Add_New_Club.Children.Clear();
        //  Grid_Add_New_Club.Children.Add(newclub);
        // tempclub = new Club();
        //this.Dialoghost_AddNewClub.DataContext = tempclub;
        //}

        private void Btn_Add_League_Cover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            Cover = openFileDialog.FileName;
            if (string.Compare(Cover, "", true) != 0)
            {
                Img_League_Cover.ImageSource = new BitmapImage(new Uri(@Cover, UriKind.RelativeOrAbsolute));
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private ArrayList GetClubs()
        {
            return new ArrayList()
            {
                new Club(1,"Manchester United", "Old Tranfford", "ManchesterUnited.png", "Ole",0,0,0,0,0,0,0,0,"Red","Oldtran.jpg"),
                new Club(2,"Liver Pool", "Anfield", "Liverpool.png", "Ole",0,0,0,0,0,0,0,0,"Red","Panoramica2.jpg"),
                new Club(3,"Manchester City", "Ethiad Stadium", "ManchesterCity.png", "Ole",0,0,0,0,0,0,0,0,"Aqua","Panoramica2.jpg"),
                new Club(4,"News Castle", "St. Jame's Park", "Newcastle.png", "Ole",0,0,0,0,0,0,0,0,"Black","Oldtran.jpg"),
                new Club(5,"Everton", "Old Tranfford", "Everton.png", "Ole",0,0,0,0,0,0,0,0,"Blue","1191915482.jpg"),
                new Club(6,"Chelsea", "Stanford Bridge", "Chelsea.png", "Ole",0,0,0,0,0,0,0,0,"DarkBlue","1191915482.jpg"),
                new Club(7,"Wolverhampton", "St. Mary's Stadium", "Wolver.png", "Ole",0,0,0,0,0,0,0,0,"Orange","Panoramica2.jpg"),
                new Club(8,"Tottenham", "Tottenham Stadium", "Tottenham.png", "Ole",0,0,0,0,0,0,0,0,"Red","totsta.jpg"),
                new Club(9,"Leicester City", "Goodison Park", "LeicesterCity.png", "Ole",0,0,0,0,0,0,0,0,"Blue","Oldtran.jpg"),
                new Club(10,"Watford", "Vicarage Road", "Watford.png", "Ole",0,0,0,0,0,0,0,0,"Orange","Oldtran.jpg"),
                new Club(11,"Burnley", "Turf Moor", "Burnley.png", "Ole",0,0,0,0,0,0,0,0,"Violet","Oldtran.jpg"),
                new Club(12,"Arsenal", "Emirates Stadium", "Arsenal.png", "Ole",0,0,0,0,0,0,0,0,"Red","1191915482.jpg")

            };
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Club_List_Box.SelectedItem != null)
            {
                MyNewLeague.ListClub.Remove(Club_List_Box.SelectedItem as Club);
                CollectionViewSource.GetDefaultView(Club_List_Box.ItemsSource).Refresh();
            }
        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            Card_ALLClubs.Visibility = Visibility.Collapsed;
            //int i = MyNewLeague.ListClub.IndexOf(Club_List_Box.SelectedItem as Club);
            UC_NEWCLUB newclub = new UC_NEWCLUB(Club_List_Box.SelectedItem as Club);
            Grid_Add_New_Club.Children.Clear();
            Grid_Add_New_Club.Children.Add(newclub);
        }



        private void Btn_Edit_Cover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            TempCoverClub = openFileDialog.FileName;
            if (string.Compare(TempCoverClub, "", true) != 0)
            {
                Club_Cover_New.ImageSource = new BitmapImage(new Uri(@TempCoverClub, UriKind.RelativeOrAbsolute));
            }
        }

        private void Btn_AddLogoClub_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            TempLogoClub = openFileDialog.FileName;
            if (string.Compare(templogoclub, "", true) != 0)
            {
                Img_Club_Logo.ImageSource = new BitmapImage(new Uri(@TempLogoClub, UriKind.RelativeOrAbsolute));

            }
        }

        private void Btn_Add_New_Club_Click(object sender, RoutedEventArgs e)
        {
            tempclub = new Club(TempCoverClub, TempLogoClub);
            this.Dialoghost_AddNewClub.DataContext = tempclub;
        }

        private void Btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression clubname = Txb_Club_Name.GetBindingExpression(TextBox.TextProperty);
            clubname.UpdateSource();
            BindingExpression manager = Txb_Manager.GetBindingExpression(TextBox.TextProperty);
            manager.UpdateSource();
            BindingExpression stadium = Txb_Stadium.GetBindingExpression(TextBox.TextProperty);
            stadium.UpdateSource();

            MyNewLeague.ListClub.Add(tempclub);
            CollectionViewSource.GetDefaultView(Club_List_Box.ItemsSource).Refresh();
        }



        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
