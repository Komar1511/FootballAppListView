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
    public partial class AddEditPageLocation : Page
    {
        private Location _currentLocation = new Location();
        private int reg = 0;
        int maxid = FootballEntities.GetContext().Location.Max(u => u.id_stadium);
        public AddEditPageLocation(Location selectedLocation)
        {
            InitializeComponent();

            if (selectedLocation != null) { 
                _currentLocation = selectedLocation;
                reg = 1;
            }
            else
            {
                _currentLocation.id_stadium = maxid + 10;
            }

            DataContext = _currentLocation;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentLocation.Name_stadium.ToString()))
                errors.AppendLine("Укажите название стадиона");
            if (string.IsNullOrWhiteSpace(_currentLocation.City.ToString()))
                errors.AppendLine("Укажите город");
            if (string.IsNullOrWhiteSpace(_currentLocation.Country.ToString()))
                errors.AppendLine("Укажите страну");
            if (reg == 0) FootballEntities.GetContext().Location.Add(_currentLocation);
            else
            {
                var foot = FootballEntities.GetContext().Location.Where(b => b.id_stadium == _currentLocation.id_stadium).FirstOrDefault();
                foot.Name_stadium = _currentLocation.Name_stadium;
                foot.City = _currentLocation.City;
                foot.Country = _currentLocation.Country;
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
                _currentLocation = new Location();
                    this.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }

