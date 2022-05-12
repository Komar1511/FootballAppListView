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
    /// Логика взаимодействия для Admin_ResultsWindow.xaml
    /// </summary>
    public partial class Admin_ResultsWindow : Page
    {
        public Admin_ResultsWindow()
        {
            InitializeComponent();
            DGridResults.ItemsSource = FootballEntities.GetContext().Results.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddEditPageResults(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ResultsForRemoving = DGridResults.SelectedItems.Cast<Results>().ToList();
            if (MessageBox.Show("Вы точно хотите Удалить/Обновить запись следующие записи", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    FootballEntities.GetContext().Results.RemoveRange(ResultsForRemoving);
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
                DGridResults.ItemsSource = FootballEntities.GetContext().Results.ToList();
            }
        }
      //  private void BtnEdit_Click(object sender, RoutedEventArgs e)
       // {
         //   var upd = DGridResults.SelectedItems.Cast<Results>().FirstOrDefault();
           // MainFrame.Navigate(new AddEditPageResults(upd));
        //}

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}