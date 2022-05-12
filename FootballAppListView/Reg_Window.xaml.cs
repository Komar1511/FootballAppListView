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
    /// Логика взаимодействия для Reg_Window.xaml 
    /// </summary> 
    public partial class Reg_Window : Window
    {
        string _login;
        private Fans _currentFans = new Fans();
        int maxid = FootballEntities.GetContext().Fans.Max(u => u.fan_id);
        public Reg_Window(Fans SelectFans)
        {
            InitializeComponent();
            if (SelectFans != null)
                _currentFans = SelectFans;
            DataContext = _currentFans;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _login = LoginText.Text;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentFans.login)) errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentFans.password)) errors.AppendLine("Введите пароль");
            if (string.IsNullOrWhiteSpace(_currentFans.Surname)) errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentFans.Name)) errors.AppendLine("Введите имя");
            if (FootballEntities.GetContext().Fans.Any(f => f.login == _login)) errors.AppendLine("Пользователь с таким логином уже существует");
            //проверка пароля: 
            string str2; int i = 0; bool boo; int yes = 0;
            if (_currentFans.password.Length < 6) errors.AppendLine("Пароль должен быть длиннее 6 символов");
            str2 = _currentFans.password.ToLower();
            if (_currentFans.password == str2) errors.AppendLine("В пароле должны быть большие буквы");
            char[] array = _currentFans.password.ToCharArray();
            while (_currentFans.password.Length > i)
            {
                boo = Char.IsDigit(array[i]);
                if (boo == true) yes = yes + 1;
                i = i + 1;
            }
            if (_currentFans.password.Length <= yes) errors.AppendLine("Пароль должен включать в себя ещё и буквы, большие и маленькие");
            if (yes == 0) errors.AppendLine("Пароль должен включать в себя ещё и цифры");
            if (errors.Length > 0) { MessageBox.Show(errors.ToString()); return;
            }


            _currentFans.fan_id = maxid + 1;
            FootballEntities.GetContext().Fans.Add(_currentFans);

            try
            {
                FootballEntities.GetContext().SaveChanges();
                MessageBox.Show("Okey!");
                StartWindow win1 = new StartWindow();
                win1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            StartWindow win1 = new StartWindow();
            win1.Show();
            this.Close();

        }
    }
}