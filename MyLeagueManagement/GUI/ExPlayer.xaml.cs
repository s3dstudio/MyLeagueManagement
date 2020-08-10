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
    /// Interaction logic for ExPlayer.xaml
    /// </summary>
    public partial class ExPlayer : UserControl, INotifyPropertyChanged
    {
        ArrayList MyListPlayer = new ArrayList();
        ArrayList TempPlayer = new ArrayList();

        public event PropertyChangedEventHandler PropertyChanged;

        public ExPlayer()
        {
            InitializeComponent();
            //DatePickerXX.BlackoutDates.AddDatesInPast();
            MyListPlayer = GetPlayer();
            //var MyListPlayer = GetPlayer();
            if (MyListPlayer.Count > 0)
            {
                PlayerListBox.ItemsSource = MyListPlayer;
            }
            //Int32 index = MyListPlayer.IndexOf(PlayerListBox.SelectedItem as Player);
            //object tempplayer = MyListPlayer[index];

            //ArrayList TempPlayer = new ArrayList();
           
        }

        private ArrayList GetPlayer()
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
            return new ArrayList()
            {
            new Player("Mohamed Salah",11,tempDate, "Forward", "Egypt","Sala.png","Liverpool","ManchesterUnited.png",21),
            new Player("Fabinho", 6,tempDate, "Midfielder", "Brazil", "Fabinho.png", "Liverpool","ManchesterUnited.png", 1),
            new Player("Sadio Mane", 5,tempDate, "Midfielder", "Senegal", "Mane.png", "Liverpool","ManchesterUnited.png", 14)
            };
        }

        private void BtnEdit1_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerListBox.SelectedItem != null)
            {
                
                //CollectionViewSource.GetDefaultView(PlayerListBox.ItemsSource).Refresh();
                // TempPlayer.Clear();                     
                int i = MyListPlayer.IndexOf(PlayerListBox.SelectedItem as Player);

                //DialogPlayer.ItemsSource = TempPlayer;
                //Player tempp = PlayerListBox.SelectedItem as Player;
                //CheckedPlayer.ItemsSource = MyListPlayer;
                //this.DataContext = MyListPlayer[i];
                this.CheckedPlayer.DataContext = MyListPlayer[i];
            }


        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
           if(PlayerListBox.SelectedItem != null)
            {
                BindingExpression be = PlayerNameTxb.GetBindingExpression(TextBox.TextProperty);
                be.UpdateSource();
                // MyListPlayer.Remove(PlayerListBox.SelectedItem as Player);
                // MyListPlayer.Add(TempPlayer[0]);
                CollectionViewSource.GetDefaultView(PlayerListBox.ItemsSource).Refresh();
                PlayerListBox.SelectedItem = null;
               
            }
           
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            
            CollectionViewSource.GetDefaultView(PlayerListBox.ItemsSource).Refresh();
            int i = MyListPlayer.IndexOf(PlayerListBox.SelectedItem as Player);
            this.CheckedPlayer.DataContext = MyListPlayer[i];
            PlayerListBox.SelectedItem = null;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
