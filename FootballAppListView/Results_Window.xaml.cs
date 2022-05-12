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
    /// Логика взаимодействия для Results_Window.xaml
    /// </summary>
    public partial class Results_Window : Window
    {
        public Results_Window()
        {
            InitializeComponent();
            DGridResults.ItemsSource = FootballEntities.GetContext().Match_Location().ToList();
        }

            private void BtnHome_Click(object sender, RoutedEventArgs e)
            {
                StartWindow win1 = new StartWindow();
                win1.Show();
                this.Close();
            }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Main_Window win2 = new Main_Window();
            win2.Show();
            this.Close();

        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {
            var SelectOtchet = DGridResults.SelectedItems.Cast<Match_Location_Result>().FirstOrDefault();
            Otchet otchet = new Otchet(SelectOtchet);
            otchet.Show();
        }
    }
}
