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
    public partial class AddEditPagePlayers : Page
    {
        private Players _currentPlayers = new Players();
        private int reg = 0;
        int maxid = FootballEntities.GetContext().Players.Max(u => u.id_player);
        public AddEditPagePlayers(Players selectedPlayers)
        {
            InitializeComponent();

            if (selectedPlayers != null) { 
                _currentPlayers = selectedPlayers;
                reg = 1;
            }
            else
            {
                _currentPlayers.id_player = maxid + 1;
            }

            DataContext = _currentPlayers;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPlayers.id_club.ToString()))
                errors.AppendLine("Укажите номер клуба");
            if (string.IsNullOrWhiteSpace(_currentPlayers.Surname.ToString()))
                errors.AppendLine("Укажите фамилию игрока");
            if (string.IsNullOrWhiteSpace(_currentPlayers.Name.ToString()))
                errors.AppendLine("Укажите имя игрока");
            if (string.IsNullOrWhiteSpace(_currentPlayers.Position.ToString()))
                errors.AppendLine("Укажите позицию игрока");
            if (string.IsNullOrWhiteSpace(_currentPlayers.Number_player.ToString()))
                errors.AppendLine("Укажите номер(в клубе) игрока");
            if (reg == 0) FootballEntities.GetContext().Players.Add(_currentPlayers);
            else
            {
                var foot = FootballEntities.GetContext().Players.Where(b => b.id_player == _currentPlayers.id_player).FirstOrDefault();
                foot.id_club = _currentPlayers.id_club;
                foot.Surname = _currentPlayers.Surname;
                foot.Name = _currentPlayers.Name;
                foot.Position = _currentPlayers.Position;
                foot.Number_player = _currentPlayers.Number_player;
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

                try
                {
                    FootballEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена. Обновите таблицу");
                _currentPlayers = new Players();
                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
