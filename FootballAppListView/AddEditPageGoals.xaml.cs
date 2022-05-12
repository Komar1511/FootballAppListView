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
    public partial class AddEditPageGoals : Page
    {
        private Goals _currentGoals = new Goals();
        public AddEditPageGoals(Goals selectedGoals)
        {
            InitializeComponent();

            if (selectedGoals != null) 
                _currentGoals = selectedGoals;


            DataContext = _currentGoals;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentGoals.id_club.ToString()))
                errors.AppendLine("Укажите номер клуба");
            if (string.IsNullOrWhiteSpace(_currentGoals.id_player.ToString()))
                errors.AppendLine("Укажите номер(ID) игрока");
            if (string.IsNullOrWhiteSpace(_currentGoals.id_match.ToString()))
                errors.AppendLine("Укажите номер матча");
            if (string.IsNullOrWhiteSpace(_currentGoals.Score.ToString()))
                errors.AppendLine("Укажите количество голов");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                FootballEntities.GetContext().Goals.Add(_currentGoals);

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
