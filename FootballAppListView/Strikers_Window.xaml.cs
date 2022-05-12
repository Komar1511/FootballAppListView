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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Strikers_Window : Window
    {
        public Strikers_Window()
        {
            InitializeComponent();
            Strikers_class.StrikersFrame = StrikersFrame;
            ComboStrikers.Items.Add("ТОП-5");
            ComboStrikers.Items.Add("Все бомбардиры");

        }

        private void ComboStrikers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Main_Window2 win3 = new Main_Window2();
            win3.Show();
            this.Close();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (ComboStrikers.SelectedIndex == 0) //первый элемент списка
            {
                
                Strikers_class.StrikersFrame.Content = new Strikers_Page1();
            }
            if (ComboStrikers.SelectedIndex == 1)//второй элемент списка
            {
                Strikers_class.StrikersFrame.Content = new Strikers_Page2();
            }
        }
    }
}
