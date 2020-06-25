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
    /// Interaction logic for UC_TABLES.xaml
    /// </summary>
    public partial class UC_TABLES : UserControl
    {
        public UC_TABLES()
        {
            InitializeComponent();
            var clubs = GetClubs();
            if (clubs.Count > 0)
            {
                ListViewTable.ItemsSource = clubs;
            }
            //int CountClub = clubs.Count;
            //List<int> GetPos = new List<int>(CountClub);
            //for (int i = 1; i <= CountClub; i++)
            //{
            //    GetPos.Add(i);
            //}
            //ListViewPos.ItemsSource = GetPos;

        }
        private List<Club> GetClubs()
        {
            return new List<Club>()
            {
                new Club(1,"Manchester United", "Old Tranfford", "ManchesterUnited.png", "Ole",29,12,9,8,45,44,30,14,"Red","Oldtran.jpg"),
                new Club(2,"Liverpool", "Anfield", "Liverpool.png", "Kloop",29,27,1,1,82,66,21,45,"Red","Panoramica2.jpg"),
                new Club(3,"Manchester City", "Ethiad Stadium", "ManchesterCity.png", "Pep",28,18,3,7,57,68,31,37,"Aqua","Panoramica2.jpg"),
                new Club(4,"News Castle", "St. Jame's Park", "Newcastle.png", "Ole",29,9,8,12,35,25,41,-16,"Black","Oldtran.jpg"),
                new Club(5,"Everton", "Old Tranfford", "Everton.png", "Ole",29,10,7,12,37,37,46,-9,"Blue","1191915482.jpg"),
                new Club(6,"Chelsea", "Stanford Bridge", "Chelsea.png", "Frank Lampard",29,14,6,9,48,51,39,12,"DarkBlue","1191915482.jpg"),
                new Club(7,"Wolverhampton", "St. Mary's Stadium", "Wolver.png", "Ole",29,10,13,6,43,41,34,7,"Orange","Panoramica2.jpg"),
                new Club(8,"Tottenham", "Tottenham Stadium", "Tottenham.png", "Mourinho",29,11,8,10,41,47,40,7,"Red","totsta.jpg"),
                new Club(9,"Leicester City", "Goodison Park", "LeicesterCity.png", "Ole",29,15,5,8,53,58,28,30,"Blue","Oldtran.jpg"),
                new Club(10,"Watford", "Vicarage Road", "Watford.png", "Ole",0,0,0,0,0,0,0,0,"Orange","Oldtran.jpg"),
                new Club(11,"Burnley", "Turf Moor", "Burnley.png", "Ole",0,0,0,0,39,0,0,0,"Violet","Oldtran.jpg"),
                new Club(12,"Arsenal", "Emirates Stadium", "Arsenal.png", "Ole",28,9,13,6,40,40,36,4,"Red","1191915482.jpg")

            };
        }
    }
}
