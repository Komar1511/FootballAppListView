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
    /// Логика взаимодействия для Clubs_Window2.xaml
    /// </summary>
    public partial class Clubs_Window : Window
    {
        public Clubs_Window()
        {
            InitializeComponent();
            DGridClubs.ItemsSource = FootballEntities.GetContext().Clubs.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Main_Window win2 = new Main_Window();
            win2.Show();
            this.Close();
        }
    }
}
