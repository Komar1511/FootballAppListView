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
    /// Логика взаимодействия для Coaches.xaml 
    /// </summary> 
    public partial class Coaches_Window : Window
    {
        public Coaches_Window()
        {
            InitializeComponent();
            LViewCoaches.ItemsSource = FootballEntities.GetContext().Coaches_proc().ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Main_Window win2 = new Main_Window();
            win2.Show();
            this.Close();
        }
    }
}