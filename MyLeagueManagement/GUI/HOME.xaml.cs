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
//using DAL;

namespace GUI
{
    /// <summary>
    /// Interaction logic for HOME.xaml
    /// </summary>
    public partial class HOME : UserControl
    {
      //  ConnectDatabase connectDatabase = new ConnectDatabase();
      //  ConnectStorage connectStorage = new ConnectStorage();
        public HOME()
        {
            InitializeComponent();
            //try
            //{
            //    connectDatabase.Load();
            //}
            //catch
            //{
            //    if (connectDatabase.client == null)
            //    {
            //        MessageBox.Show("Connection failed!");
            //    }
            //}
            //if (connectDatabase.client != null)
            //{
            //    MessageBox.Show("Connection is established!");
            //}
        }
        
    }
}
