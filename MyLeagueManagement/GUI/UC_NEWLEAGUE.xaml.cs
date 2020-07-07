using DTO;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
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
            HttpClient client = new HttpClient();
            // server local
            client.BaseAddress = new Uri("https://localhost:44392/");
            var response = client.GetAsync("api/clubs");
            response.Wait();
            var readData = response.Result;
            List<ClubsDTO> listClub = new List<ClubsDTO>();
            if (readData.IsSuccessStatusCode)
            {
                var jsonData = readData.Content.ReadAsStringAsync();
                string jsonString = jsonData.Result;
                var Data = DTO.ClubsDTO.FromJson(jsonString);
                listClub = Data.Select(kvp => kvp.Value).ToList();  
            }
            ArrayList arrayList = new ArrayList();
            foreach (ClubsDTO clubs in listClub)
            {
                arrayList.Add(clubs);
            }
            return arrayList;
        }
        private ClubsDTO GetClubsByKey(string Key)
        {
            HttpClient client = new HttpClient();
            // server local
            client.BaseAddress = new Uri("https://localhost:44392/");
            var response = client.GetAsync("api/clubs/getbykey/"+Key);
            response.Wait();
            var readData = response.Result;
            List<ClubsDTO> listClub = new List<ClubsDTO>();
            if (readData.IsSuccessStatusCode)
            {
                var jsonData = readData.Content.ReadAsStringAsync();
                string jsonString = jsonData.Result;
                var Data = DTO.ClubsDTO.FromJson(jsonString);
                listClub = Data.Select(kvp => kvp.Value).ToList();
            }
            return listClub.First();
        }
        private void UpdateKey()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44392/");
            var response = client.GetAsync("api/clubs");
            response.Wait();
            var readData = response.Result;
            List<ClubsDTO> listClub = new List<ClubsDTO>();
            if (readData.IsSuccessStatusCode)
            {
                var jsonData = readData.Content.ReadAsStringAsync();
                string jsonString = jsonData.Result;
                var Data = DTO.ClubsDTO.FromJson(jsonString);
                foreach(KeyValuePair<string, ClubsDTO> value in Data)
                {
                    value.Value._Key = value.Key;
                }
                listClub = Data.Select(kvp => kvp.Value).ToList();
            }
            foreach(ClubsDTO value in listClub)
            {
                PutClub(value);
            }
           
        }
        private void PostClub(ClubsDTO club)
        {
            HttpClient client = new HttpClient();
            // server local
            client.BaseAddress = new Uri("https://localhost:44392/");
            var response = client.PostAsJsonAsync("api/clubs", club);
            response.Wait();
        }
        private void DeleteClub(ClubsDTO club)
        {
            if (club != null)
            {
                HttpClient client = new HttpClient();
                // server local
                client.BaseAddress = new Uri("https://localhost:44392/");
                var response = client.DeleteAsync("api/clubs/delete/" + club._Key);
                response.Wait();
            }
        }
        private void PutClub(ClubsDTO club)
        {
            if (club._Key != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44392/");
                var response = client.PutAsJsonAsync("api/clubs", club);
                response.Wait();
            }
        }
        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Club_List_Box.SelectedItem != null)
            {
                ClubsDTO cl =  Club_List_Box.SelectedItem as ClubsDTO;
                DeleteClub(cl);
                MyNewLeague.ListClub.Remove(cl);
                   
                CollectionViewSource.GetDefaultView(Club_List_Box.ItemsSource).Refresh();
            }
        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            Card_ALLClubs.Visibility = Visibility.Collapsed;
            //int i = MyNewLeague.ListClub.IndexOf(Club_List_Box.SelectedItem as Club);
            ClubsDTO clubsDTO = Club_List_Box.SelectedItem as ClubsDTO;
            UC_NEWCLUB newclub = new UC_NEWCLUB(clubsDTO);
            Grid_Add_New_Club.Children.Clear();
            Grid_Add_New_Club.Children.Add(newclub);
            PutClub(clubsDTO);
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
            ClubsDTO clubs = new ClubsDTO();
            clubs.ClubName = tempclub.ClubName;
            clubs.Manager = tempclub.Manager;
            clubs.Stadium = tempclub.Stadium;
            PostClub(clubs);
            UpdateKey();
            MyNewLeague.ListClub.Add(tempclub);
            CollectionViewSource.GetDefaultView(Club_List_Box.ItemsSource).Refresh();
        }



        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
