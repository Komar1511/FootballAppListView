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

    public partial class StartWindow : Window
    {
        public static int index = 0;
        string _login, _password;
        public StartWindow()
        {
            InitializeComponent();
            //MainFrame.Navigate(new ClubsPage());
            //Manager.MainFrame = MainFrame;
        }



        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Reg_Window win7 = new Reg_Window(null);
            win7.Show();
            this.Close();
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            Admins Admin = null;

            _login = LoginText.Text;
            _password = PasswordText.Password;
            Admin = FootballEntities.GetContext().Admins.Where(b => b.password_adm == _password && b.login_adm == _login).FirstOrDefault();

            if (Admin == null) MessageBox.Show("Не найдено");
            else
            {
                MessageBox.Show("Успешно");
                index = -1;
                Admin_MenuWindow win11 = new Admin_MenuWindow();
                win11.Show();
                this.Close();
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Fans User = null;

            _login = LoginText.Text;
            _password = PasswordText.Password;
            User = FootballEntities.GetContext().Fans.Where(b => b.password == _password && b.login == _login).FirstOrDefault();
            if (User == null) MessageBox.Show("Не найдено");
            else
            {
                MessageBox.Show("Успешно");
                index = User.fan_id;
                Main_Window win2 = new Main_Window();
                win2.Show();
                this.Close();
            }

            
        }
    }
}
            

