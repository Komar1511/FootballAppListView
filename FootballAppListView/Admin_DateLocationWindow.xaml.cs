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
    /// Логика взаимодействия для Admin_DateLocationWindow.xaml
    /// </summary>
    public partial class Admin_DateLocationWindow : Page
    {
        public Admin_DateLocationWindow()
        {
            InitializeComponent();
            DGridDateLoc.ItemsSource = FootballEntities.GetContext().Date_Location.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditPageDateLoc(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var upd = DGridDateLoc.SelectedItems.Cast<Date_Location>().FirstOrDefault();
            MainFrame.Navigate(new AddEditPageDateLoc(upd));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var DateLocForRemoving = DGridDateLoc.SelectedItems.Cast<Date_Location>().ToList();
            if (MessageBox.Show("Вы точно хотите Удалить/Обновить запись следующие записи", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FootballEntities.GetContext().Date_Location.RemoveRange(DateLocForRemoving);
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
                DGridDateLoc.ItemsSource = FootballEntities.GetContext().Date_Location.ToList();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
