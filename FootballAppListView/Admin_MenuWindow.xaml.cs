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
    /// Логика взаимодействия для Admin_MenuWindow.xaml
    /// </summary>
    public partial class Admin_MenuWindow : Window
    {
        public Admin_MenuWindow()
        {
            InitializeComponent();
        }

        private void BtnAdmins_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admins_AdminsWindow());
        }

        private void BtnFans_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admin_UsersWindow());
        }

        private void BtnClubs_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admin_ClubWindow());
        }

        private void BtnCoaches_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admins_CoachesWindow());
        }

        private void BtnDateLocation_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admin_DateLocationWindow());
        }

        private void BtnStadium_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admin_StadiumWindow());

        }

        private void BtnGoals_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admins_GoalsWindow());
        }

        private void BtnPlayers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admins_PlayersWindow());
        }

        private void BtnResults_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admin_ResultsWindow());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            StartWindow win1 = new StartWindow();
            win1.Show();
            this.Close();
        }
    }
}
