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
    public partial class AddEditPageUser : Page
    {
        private Fans _currentFans = new Fans();
        private int reg = 0;
        int maxid = FootballEntities.GetContext().Fans.Max(u => u.fan_id);
        public AddEditPageUser(Fans selectedFans)
        {
            InitializeComponent();

            if (selectedFans != null)
            {
                _currentFans = selectedFans;
                reg = 1;
            }
            else
            {
                _currentFans.fan_id = maxid + 1;
            }

                DataContext = _currentFans;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentFans.login.ToString()))
                errors.AppendLine("Укажите Логин пользователя");
            if (string.IsNullOrWhiteSpace(_currentFans.password.ToString()))
                errors.AppendLine("Укажите пароль пользователя");
            if (string.IsNullOrWhiteSpace(_currentFans.Surname.ToString()))
                errors.AppendLine("Укажите фамилию пользователя");
            if (string.IsNullOrWhiteSpace(_currentFans.Name.ToString()))
                errors.AppendLine("Укажите имя пользователя");
            if (reg == 0) FootballEntities.GetContext().Fans.Add(_currentFans);
            else
            {
                var foot = FootballEntities.GetContext().Fans.Where(b => b.fan_id == _currentFans.fan_id).FirstOrDefault();
                foot.login = _currentFans.login;
                foot.password = _currentFans.password;
                foot.Surname = _currentFans.Surname;
                foot.Name = _currentFans.Name;
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
                _currentFans = new Fans();
                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }

