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
    public partial class AddEditPageClub : Page
    {
        private Clubs _currentClubs = new Clubs();
        private int reg = 0;
        int maxid = FootballEntities.GetContext().Clubs.Max(u => u.id_club);
        public AddEditPageClub(Clubs selectedClubs)
        {
            InitializeComponent();

            if (selectedClubs != null)
            {
                _currentClubs = selectedClubs;
                reg = 1;
            }
            else
            {
                _currentClubs.id_club = maxid + 1;
            }

                DataContext = _currentClubs;
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClubs.name_club.ToString()))
                errors.AppendLine("Укажите название клуба");
            if (string.IsNullOrWhiteSpace(_currentClubs.city.ToString()))
                errors.AppendLine("Укажите город клуба");
            if (string.IsNullOrWhiteSpace(_currentClubs.country.ToString()))
                errors.AppendLine("Укажите страну клуба");
            if (string.IsNullOrWhiteSpace(_currentClubs.id_coach.ToString()))
                errors.AppendLine("Укажите номер тренера");
            if (reg == 0) FootballEntities.GetContext().Clubs.Add(_currentClubs);
            else
            {
                var foot = FootballEntities.GetContext().Clubs.Where(b => b.id_club == _currentClubs.id_club).FirstOrDefault();
                foot.name_club = _currentClubs.name_club;
                foot.city = _currentClubs.city;
                foot.country = _currentClubs.country;
                foot.id_coach = _currentClubs.id_coach;
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
                _currentClubs = new Clubs();
                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }

