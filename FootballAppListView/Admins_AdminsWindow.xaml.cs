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
    /// Логика взаимодействия для Admins_AdminsWindow.xaml
    /// </summary>
    public partial class Admins_AdminsWindow : Page
    {
        public Admins_AdminsWindow()
        {
            InitializeComponent();
            DGridAdmins.ItemsSource = FootballEntities.GetContext().Admins.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditPageAdmin(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var AdminsForRemoving = DGridAdmins.SelectedItems.Cast<Admins>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить следующие записи", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FootballEntities.GetContext().Admins.RemoveRange(AdminsForRemoving);
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
               // FootballEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridAdmins.ItemsSource = FootballEntities.GetContext().Admins.ToList();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var upd = DGridAdmins.SelectedItems.Cast<Admins>().FirstOrDefault();
            MainFrame.Navigate(new AddEditPageAdmin(upd));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            
            this.Visibility = Visibility.Hidden;
            
        }
    }
}
