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
using System.Collections;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UC_FIXTURES.xaml
    /// </summary>
    public partial class UC_FIXTURES : UserControl
    {
        public UC_FIXTURES()
        {
            InitializeComponent();
            var clubs = GetAllClubs();
            var Round = GetRoundMatch(clubs);
            var Round1 = Round[0];
            var Round2 = Round[1];
            ListMatch.ItemsSource = (ArrayList)Round1;
            
        }

        private ArrayList GetAllClubs()
        {
            return new ArrayList()
            {
                new Club(1,"Manchester United", "Old Tranfford", "ManchesterUnited.png", "Ole",0,0,0,0,0,0,0,0,"Red","Oldtran.jpg"),
                new Club(2,"Liver Pool", "Anfield", "Liverpool.png", "Ole",0,0,0,0,0,0,0,0,"Red","Panoramica2.jpg"),
                new Club(3,"Manchester City", "Ethiad Stadium", "ManchesterCity.png", "Ole",0,0,0,0,0,0,0,0,"Aqua","Panoramica2.jpg"),
                new Club(4,"News Castle", "St. Jame's Park", "Newcastle.png", "Ole",0,0,0,0,0,0,0,0,"Black","Oldtran.jpg"),
                new Club(5,"Everton", "Old Tranfford", "Everton.png", "Ole",0,0,0,0,0,0,0,0,"Blue","1191915482.jpg"),
                new Club(6,"Chelsea", "Stanford Bridge", "Chelsea.png", "Ole",0,0,0,0,0,0,0,0,"DarkBlue","1191915482.jpg"),
                //new Club(7,"Wolverhampton", "St. Mary's Stadium", "Wolver.png", "Ole",0,0,0,0,0,0,0,0,"Orange","Panoramica2.jpg"),
                //new Club(8,"Tottenham", "Tottenham Stadium", "Tottenham.png", "Ole",0,0,0,0,0,0,0,0,"Red","totsta.jpg"),
                //new Club(9,"Leicester City", "Goodison Park", "LeicesterCity.png", "Ole",0,0,0,0,0,0,0,0,"Blue","Oldtran.jpg"),
                //new Club(10,"Watford", "Vicarage Road", "Watford.png", "Ole",0,0,0,0,0,0,0,0,"Orange","Oldtran.jpg"),
                //new Club(11,"Burnley", "Turf Moor", "Burnley.png", "Ole",0,0,0,0,0,0,0,0,"Violet","Oldtran.jpg"),
                //new Club(12,"Arsenal", "Emirates Stadium", "Arsenal.png", "Ole",0,0,0,0,0,0,0,0,"Red","1191915482.jpg")

            };
        }

        private ArrayList GetRoundMatch(ArrayList AllClubs)
        {
            int n = AllClubs.Count;
            ArrayList Round1 = new ArrayList();
            ArrayList Round2 = new ArrayList();
            if (n > 0)
            {
                
                foreach (Club i in AllClubs)
                {
                    foreach (Club j in AllClubs)
                    {
                        if (AllClubs.IndexOf(i) != AllClubs.IndexOf(j))
                        {

                            if (AllClubs.IndexOf(i) > AllClubs.IndexOf(j))
                            {
                                Round1.Add(new Match(i, j));
                            }
                            else if(AllClubs.IndexOf(i) < AllClubs.IndexOf(j)) 
                                Round2.Add(new Match(i, j));
                        }

                    }
                }
            }
            return new ArrayList(2){Round1, Round2};
        }
    }
}
