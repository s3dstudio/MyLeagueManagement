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
using DTO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UC_NEWCLUB.xaml
    /// </summary>
    public partial class UC_NEWCLUB : UserControl, INotifyPropertyChanged
    {
        public string tempcoverclub = null;
        public string templogoclub = null;

        private ClubsDTO myclub;
        public ClubsDTO MyClub
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

        public UC_NEWCLUB(ClubsDTO abc)
        {
            this.MyClub = abc;
            InitializeComponent();
            Card_Player.Visibility = Visibility.Collapsed;
            Card_General.Visibility = Visibility.Visible;
            this.DataContext = abc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(60 + (140 * index), 0, 0, 0);


            switch (index)
            {
                case 0:
                    Card_Player.Visibility = Visibility.Collapsed;
                    Card_General.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Card_General.Visibility = Visibility.Collapsed;
                    Card_Player.Visibility = Visibility.Visible;
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
                Img_Club_Cover.ImageSource = new BitmapImage(new Uri(@ClubCover, UriKind.RelativeOrAbsolute));
                this.MyClub.CoverImage = ClubCover;
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
                Img_Club_Logo.ImageSource = new BitmapImage(new Uri(@ClubLogo, UriKind.RelativeOrAbsolute));
                this.MyClub.Logo = ClubLogo;
            }
        }
    }
}

