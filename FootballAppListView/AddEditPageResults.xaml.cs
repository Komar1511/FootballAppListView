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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballAppListView
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPageResults : Page
    {
        private Results _currentResults = new Results();
        public AddEditPageResults(Results selectedResults)
        {
            InitializeComponent();

            if (selectedResults != null)
                _currentResults = selectedResults;

            DataContext = _currentResults;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentResults.id_club.ToString()))
                errors.AppendLine("Укажите номер клуба");
            if (string.IsNullOrWhiteSpace(_currentResults.id_match.ToString()))
                errors.AppendLine("Укажите номер матча");
            if (string.IsNullOrWhiteSpace(_currentResults.Final_Score.ToString()))
                errors.AppendLine("Укажите итоговый счёт матча");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                FootballEntities.GetContext().Results.Add(_currentResults);
                                
                try
                {
                    FootballEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена. Обновите таблицу");
                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
