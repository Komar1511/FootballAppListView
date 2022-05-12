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
    /// Логика взаимодействия для Stadium_Window.xaml
    /// </summary>
    public partial class Stadium_Window : Window
    {
        public Stadium_Window()
        {
            InitializeComponent();
            LViewStaidum.ItemsSource = FootballEntities.GetContext().Location.ToList();
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            Main_Window2 win3 = new Main_Window2();
            win3.Show();
            this.Close();

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            StartWindow win1 = new StartWindow();
            win1.Show();
            this.Close();
        }
    }
}
