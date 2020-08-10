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

            InitializeComponent();
            Grid_Info.Visibility = Visibility.Visible;
            Grid_Settings.Visibility = Visibility.Visible;
            Grid_Clubs.Visibility = Visibility.Collapsed;
            //var listclub = GetClubs();
            this.MyNewLeague = l;
           // MyNewLeague.ListClub = listclub;
            
            this.DataContext = MyNewLeague;          
            Card_Settings.DataContext = MyNewLeague.Rule;
            //if (MyNewLeague.ListClub.Count > 0)
            //{
            Club_List_Box.ItemsSource = MyNewLeague.ListClub;
            Club_List_Box.SelectedItem = null;
            

            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(20 + (100 * index), 0, 0, 0);


            switch (index)
            {
                case 0:
                    Grid_Info.Visibility = Visibility.Visible;
                    Grid_Clubs.Visibility = Visibility.Collapsed;
                    Grid_Settings.Visibility = Visibility.Collapsed;
                    Scrollv.ScrollToVerticalOffset(340);
                    
                    break;
                case 1:
                    Grid_Info.Visibility = Visibility.Collapsed;
                    Grid_Clubs.Visibility = Visibility.Collapsed;
                    Grid_Settings.Visibility = Visibility.Visible;
                    
                    break;
                case 2:
                    Scrollv.ScrollToVerticalOffset(340);
                    Grid_Info.Visibility = Visibility.Collapsed;
                    Grid_Settings.Visibility = Visibility.Collapsed;
                    Grid_Clubs.Visibility = Visibility.Visible;

                   // if (this.MyNewLeague.ListClub.Count > 0)
                   // {
                        Club_List_Box.SelectedItem = null;
                        //CollectionViewSource.GetDefaultView(Club_List_Box.ItemsSource).Refresh();
                        Card_ALLClubs.Visibility = Visibility.Visible;
                        this.Btn_Modify.IsEnabled = false;
                        this.Btn_Remove.IsEnabled = false;
                        this.Btn_Add_New_Club.IsEnabled = true;
                        Grid_Add_New_Club.Children.Clear();
                    //}
                   

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
                
                Img_Logo.Source = new BitmapImage(new Uri(@Logo, UriKind.RelativeOrAbsolute));
            }
        }

        private void Btn_ShowListClub_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Club_List_Box.ItemsSource).Refresh();
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
                Img_League_Cover.Source = new BitmapImage(new Uri(@Cover, UriKind.RelativeOrAbsolute));
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
                //new Club(1,"Manchester United", "Old Tranfford", "ManchesterUnited.png", "Ole",0,0,0,0,0,0,0,0,"Red","Oldtran.jpg"),
                //new Club(2,"Liver Pool", "Anfield", "Liverpool.png", "Ole",0,0,0,0,0,0,0,0,"Red","Panoramica2.jpg"),
                //new Club(3,"Manchester City", "Ethiad Stadium", "ManchesterCity.png", "Ole",0,0,0,0,0,0,0,0,"Aqua","Panoramica2.jpg"),
                //new Club(4,"News Castle", "St. Jame's Park", "Newcastle.png", "Ole",0,0,0,0,0,0,0,0,"Black","Oldtran.jpg"),
                //new Club(5,"Everton", "Old Tranfford", "Everton.png", "Ole",0,0,0,0,0,0,0,0,"Blue","1191915482.jpg"),
                //new Club(6,"Chelsea", "Stanford Bridge", "Chelsea.png", "Ole",0,0,0,0,0,0,0,0,"DarkBlue","1191915482.jpg"),
                //new Club(7,"Wolverhampton", "St. Mary's Stadium", "Wolver.png", "Ole",0,0,0,0,0,0,0,0,"Orange","Panoramica2.jpg"),
                //new Club(8,"Tottenham", "Tottenham Stadium", "Tottenham.png", "Ole",0,0,0,0,0,0,0,0,"Red","totsta.jpg"),
                //new Club(9,"Leicester City", "Goodison Park", "LeicesterCity.png", "Ole",0,0,0,0,0,0,0,0,"Blue","Oldtran.jpg"),
                //new Club(10,"Watford", "Vicarage Road", "Watford.png", "Ole",0,0,0,0,0,0,0,0,"Orange","Oldtran.jpg"),
                //new Club(11,"Burnley", "Turf Moor", "Burnley.png", "Ole",0,0,0,0,0,0,0,0,"Violet","Oldtran.jpg"),
                //new Club(12,"Arsenal", "Emirates Stadium", "Arsenal.png", "Ole",0,0,0,0,0,0,0,0,"Red","1191915482.jpg")

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
            if (Club_List_Box.SelectedItem != null)
            {
                Card_ALLClubs.Visibility = Visibility.Collapsed;
                int i = MyNewLeague.ListClub.IndexOf(Club_List_Box.SelectedItem as Club);
                UC_NEWCLUB newclub = new UC_NEWCLUB(MyNewLeague.ListClub[i] as Club);
                Grid_Add_New_Club.Children.Clear();
                Grid_Add_New_Club.Children.Add(newclub);
            }
            
        }



        private void Btn_Edit_Cover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            string tempCoverClub = null;
            tempCoverClub = openFileDialog.FileName;
            if (string.Compare(tempCoverClub, "", true) != 0)
            {
                Club_Cover_New.Source = new BitmapImage(new Uri(@tempCoverClub, UriKind.RelativeOrAbsolute));
            }
        }

        private void Btn_AddLogoClub_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFileDialog.ShowDialog();
            TempLogoClub = null;
            TempLogoClub = openFileDialog.FileName;
            if (string.Compare(TempLogoClub, "", true) != 0)
            {
                Img_Club_Logo.Source = new BitmapImage(new Uri(@TempLogoClub, UriKind.RelativeOrAbsolute));

            }
        }

        private void Btn_Add_New_Club_Click(object sender, RoutedEventArgs e)
        {
            tempclub = new Club(0, "", "", "MissLogo.jpg", "", 0, 0, 0, 0, 0, 0, 0, 0, "Red", "83330.jpg");
            
            this.Dialoghost_AddNewClub.DataContext = tempclub;
        }
        //confirm and add new club or edited club infor
        private void Btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression im = Club_Cover_New.GetBindingExpression(Image.SourceProperty);
            im.UpdateSource();
            BindingExpression imlogo = Img_Club_Logo.GetBindingExpression(Image.SourceProperty);
            imlogo.UpdateSource();
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
            this.Dialoghost_AddNewClub.DataContext = null;
        }

        private void Club_List_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Club_List_Box.SelectedItem == null)
            {
                this.Btn_Modify.IsEnabled = false;
                this.Btn_Remove.IsEnabled = false;
                this.Btn_Add_New_Club.IsEnabled = true;
            }
            else
            {
                this.Btn_Modify.IsEnabled = true;
                this.Btn_Remove.IsEnabled = true;
                this.Btn_Add_New_Club.IsEnabled = false;
            }
        }

   

        private void Btn_Active_League_Click(object sender, RoutedEventArgs e)
        {
            
            ((Grid)this.Parent).Children.Remove(this);
            this.MyNewLeague.IsActive = true;
        }

       
    }
}
