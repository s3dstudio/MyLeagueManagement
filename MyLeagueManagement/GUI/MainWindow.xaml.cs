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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            // MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            HOME h = new HOME();
            GridMainWindow.Children.Clear();
           GridMainWindow.Children.Add(h);
            // this is cmt

        }



        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MyLeagues_Click(object sender, RoutedEventArgs e)
        {
            //UC_ALLLEAGUE l = new UC_ALLLEAGUE();
            //UC_LEAGUE l = new UC_LEAGUE();
            UC_MYLEAGUES l = new UC_MYLEAGUES();
            GridMain.Children.Clear();
           GridMain.Children.Add(l);

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
           HOME h = new HOME();
            GridMain.Children.Clear();
            GridMainWindow.Children.Clear();
           GridMainWindow.Children.Add(h);

        }

        private void Ex_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WindowGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
