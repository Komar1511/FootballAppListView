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
    /// Логика взаимодействия для Main_Window2.xaml
    /// </summary>
    public partial class Main_Window2 : Window
    {
        
        public Main_Window2()
        {
            InitializeComponent();
        }
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            StartWindow win1 = new StartWindow();
            win1.Show();
            this.Close();
        }
        private void BtnStrikers_Click(object sender, RoutedEventArgs e)
        {
            Strikers_Window win4 = new Strikers_Window();
            win4.Show();
            this.Close();
        }
        private void BtnPlayers_Click(object sender, RoutedEventArgs e)
        {
            Players_Window win2 = new Players_Window();
            win2.Show();
            this.Close();
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            Main_Window win6 = new Main_Window();
            win6.Show();
            this.Close();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Stadium_Window win7 = new Stadium_Window();
            win7.Show();
            this.Close();

        }

        private void FindPlayersName2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _match;

            _match = FindPlayersName2.Text;
            if (_match == null)
            {
                DGridStrikersMatch.ItemsSource = null;
            }
            else
            {
                DGridStrikersMatch.ItemsSource = FootballEntities.GetContext().Score_In_Match().Where(b => b.id_match.ToString() == _match).ToList();
            }
        }
    }
}
