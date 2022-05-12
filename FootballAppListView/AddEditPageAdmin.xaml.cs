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
    public partial class AddEditPageAdmin : Page
    {
        private Admins _currentAdmins = new Admins();
        private int reg = 0;
        int maxid = FootballEntities.GetContext().Admins.Max(u => u.admin_id);
        public AddEditPageAdmin(Admins selectedAdmins)
        {
            InitializeComponent();

            if (selectedAdmins != null) { 
                _currentAdmins = selectedAdmins;
            reg = 1;
        } 
            else 
        { 
            _currentAdmins.admin_id = maxid + 1; 
}

    DataContext = _currentAdmins;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            
            if (string.IsNullOrWhiteSpace(_currentAdmins.login_adm.ToString()))
                errors.AppendLine("Укажите Логин админа");
            if (string.IsNullOrWhiteSpace(_currentAdmins.password_adm.ToString()))
                errors.AppendLine("Укажите пароль админа");

            if (reg == 0) FootballEntities.GetContext().Admins.Add(_currentAdmins);
            else
            {
                var foot = FootballEntities.GetContext().Admins.Where(b => b.admin_id == _currentAdmins.admin_id).FirstOrDefault();
                foot.login_adm = _currentAdmins.login_adm;
                foot.password_adm = _currentAdmins.password_adm;
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
                    _currentAdmins = new Admins();                   
                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }

