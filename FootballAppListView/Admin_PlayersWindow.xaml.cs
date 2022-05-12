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
    /// Логика взаимодействия для Admin_PlayersWindow.xaml
    /// </summary>
    public partial class Admins_PlayersWindow : Page
    {
        public Admins_PlayersWindow()
        {
            InitializeComponent();
            DGridPlayers.ItemsSource = FootballEntities.GetContext().Players.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditPagePlayers(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PlayersForRemoving = DGridPlayers.SelectedItems.Cast<Players>().ToList();
            if (MessageBox.Show("Вы точно хотите Удалить/Обновить запись следующие записи", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FootballEntities.GetContext().Players.RemoveRange(PlayersForRemoving);
                    FootballEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Admins_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //FootballEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPlayers.ItemsSource = FootballEntities.GetContext().Players.ToList();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var upd = DGridPlayers.SelectedItems.Cast<Players>().FirstOrDefault();
            MainFrame.Navigate(new AddEditPagePlayers(upd));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}