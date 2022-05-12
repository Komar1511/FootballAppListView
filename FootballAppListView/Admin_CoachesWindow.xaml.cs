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
    /// Логика взаимодействия для Admin_CoachesWindow.xaml
    /// </summary>
    public partial class Admins_CoachesWindow : Page
    {
        public Admins_CoachesWindow()
        {
            InitializeComponent();
            DGridCoach.ItemsSource = FootballEntities.GetContext().Coaches.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditPageCoach(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var CoachForRemoving = DGridCoach.SelectedItems.Cast<Coaches>().ToList();
            if (MessageBox.Show("Вы точно хотите Удалить/Обновить запись следующие записи", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FootballEntities.GetContext().Coaches.RemoveRange(CoachForRemoving);
                    FootballEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var upd = DGridCoach.SelectedItems.Cast<Coaches>().FirstOrDefault();
            MainFrame.Navigate(new AddEditPageCoach(upd));
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Admins_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //FootballEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridCoach.ItemsSource = FootballEntities.GetContext().Coaches.ToList();
            }
        }
    }
}