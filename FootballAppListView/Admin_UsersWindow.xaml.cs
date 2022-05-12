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
    /// Логика взаимодействия для Admin_UsersWindow.xaml
    /// </summary>
    public partial class Admin_UsersWindow : Page
    {
        public Admin_UsersWindow()
        {
            InitializeComponent();
            DGridFans.ItemsSource = FootballEntities.GetContext().Fans.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditPageUser(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var FansForRemoving = DGridFans.SelectedItems.Cast<Fans>().ToList();
            if (MessageBox.Show("Вы точно хотите Удалить/Обновить запись следующие записи", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FootballEntities.GetContext().Fans.RemoveRange(FansForRemoving);
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
                DGridFans.ItemsSource = FootballEntities.GetContext().Fans.ToList();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var upd = DGridFans.SelectedItems.Cast<Fans>().FirstOrDefault();
            MainFrame.Navigate(new AddEditPageUser(upd));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
