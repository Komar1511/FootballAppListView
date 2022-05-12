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
using System.Windows.Shapes;

namespace FootballAppListView
{
    /// <summary>
    /// Логика взаимодействия для Otchet.xaml
    /// </summary>
    public partial class Otchet : Window
    {
        private Match_Location_Result _currentResults = new Match_Location_Result();
        public Otchet(Match_Location_Result SelectOtchet)
        {
            InitializeComponent();
            InitializeComponent();
            _currentResults = SelectOtchet;
            nameclubtxt.Text = _currentResults.name_club.ToString();
            citytxt.Text = _currentResults.City.ToString();
            finalscoretxt.Text = _currentResults.Final_Score.ToString();
            stadiumtxt.Text = _currentResults.Name_stadium.ToString();
            idmatchtxt.Text = _currentResults.id_match.ToString();
            datetimetxt.Text = _currentResults.Date_time.ToString();

        }
    }
}
