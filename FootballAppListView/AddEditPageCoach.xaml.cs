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
    public partial class AddEditPageCoach : Page
    {
        private Coaches _currentCoach = new Coaches();
        private int reg = 0;
        int maxid = FootballEntities.GetContext().Coaches.Max(u => u.id_coach);
        public AddEditPageCoach(Coaches selectedCoach)
        {
            InitializeComponent();

            if (selectedCoach != null)
            { 
                _currentCoach = selectedCoach;
                reg = 1;
            }
            else
            {
                _currentCoach.id_coach = maxid + 1;
            }

            DataContext = _currentCoach;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();


            if (string.IsNullOrWhiteSpace(_currentCoach.Country_birth.ToString()))
                errors.AppendLine("Укажите национальность тренера");
            if (string.IsNullOrWhiteSpace(_currentCoach.Surname.ToString()))
                errors.AppendLine("Укажите фамилию тренера");
            if (string.IsNullOrWhiteSpace(_currentCoach.Name.ToString()))
                errors.AppendLine("Укажите имя тренера");

            if (reg == 0) FootballEntities.GetContext().Coaches.Add(_currentCoach);
            else
            {
                var foot = FootballEntities.GetContext().Coaches.Where(b => b.id_coach == _currentCoach.id_coach).FirstOrDefault();
                foot.Country_birth = _currentCoach.Country_birth;
                foot.Surname = _currentCoach.Surname;
                foot.Name = _currentCoach.Name;
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
                _currentCoach = new Coaches();
                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
