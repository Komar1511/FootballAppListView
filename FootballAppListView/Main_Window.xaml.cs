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
    /// Логика взаимодействия для Main_Window.xaml
    /// </summary>
    public partial class Main_Window : Window
    {
        public Main_Window()
        {
            InitializeComponent();
            DGridStrikersClubs.ItemsSource = FootballEntities.GetContext().Top_Scorer_Clubs3().ToList();
        }


        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            StartWindow win1 = new StartWindow();
            win1.Show();
            this.Close();
        }


        private void BtnClubs_Click(object sender, RoutedEventArgs e)
        {
            Clubs_Window win5 = new Clubs_Window();
            win5.Show();
            this.Close();
        }

        private void BtnPlayers_Click(object sender, RoutedEventArgs e)
        {
            Players_Window win2 = new Players_Window();
            win2.Show();
            this.Close();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Main_Window2 win3 = new Main_Window2();
            win3.Show();
            this.Close();
        }

        private void BtnCoaches_Click(object sender, RoutedEventArgs e)
        {
            Coaches_Window win6 = new Coaches_Window();
            win6.Show();
            this.Close();

        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            Results_Window win8 = new Results_Window();
            win8.Show();
            this.Close();

        }
    }
}
