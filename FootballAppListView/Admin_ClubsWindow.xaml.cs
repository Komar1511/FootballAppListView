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
    /// Логика взаимодействия для Admin_ClubsWindow.xaml
    /// </summary>
    public partial class Admin_ClubWindow : Page
    {
        public Admin_ClubWindow()
            {
                InitializeComponent();
                DGridClub.ItemsSource = FootballEntities.GetContext().Clubs.ToList();

            }

            private void BtnAdd_Click(object sender, RoutedEventArgs e)
            {
                MainFrame.Navigate(new AddEditPageClub(null));
            }

            private void BtnDelete_Click(object sender, RoutedEventArgs e)
            {
                var ClubsForRemoving = DGridClub.SelectedItems.Cast<Clubs>().ToList();
                if (MessageBox.Show("Вы точно хотите Удалить/Обновить запись следующие записи", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FootballEntities.GetContext().Clubs.RemoveRange(ClubsForRemoving);
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
                    FootballEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridClub.ItemsSource = FootballEntities.GetContext().Clubs.ToList();
                }
            }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var upd = DGridClub.SelectedItems.Cast<Clubs>().FirstOrDefault();
            MainFrame.Navigate(new AddEditPageClub(upd));
        }
    }
}