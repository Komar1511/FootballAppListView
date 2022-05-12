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
    /// Логика взаимодействия для club0.xaml
    /// </summary>
    public partial class Players_Window : Window
    {
        string _name;
        public Players_Window()
        {
            InitializeComponent();
            DGridPlayers.ItemsSource = FootballEntities.GetContext().Players.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Main_Window2 win6 = new Main_Window2();
            win6.Show();
            this.Close();
        }


        private void FindPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {
            Clubs Name = null;

            _name = FindPlayers.Text;
            Name = FootballEntities.GetContext().Clubs.Where(b => b.name_club == _name).FirstOrDefault();
            if (Name == null)
            {
                DGridPlayers.ItemsSource = FootballEntities.GetContext().Players.ToList();
            }
            else
            {
                DGridPlayers.ItemsSource = FootballEntities.GetContext().Players.Where(b => b.Clubs.name_club == _name).ToList();
            }
        }

        private void FindPlayersName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Players Name = null;

            _name = FindPlayersName.Text;
            Name = FootballEntities.GetContext().Players.Where(b => b.Surname == _name).FirstOrDefault();
            if (Name == null)
            {
                DGridPlayers.ItemsSource = FootballEntities.GetContext().Players.ToList();
            }
            else
            {
                DGridPlayers.ItemsSource = FootballEntities.GetContext().Players.Where(b => b.Surname == _name).ToList();
            }
        }
    }
}
