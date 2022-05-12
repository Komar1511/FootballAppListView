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
    public partial class AddEditPageDateLoc : Page
    {
        private Date_Location _currentDateLoc = new Date_Location();
        private int reg = 0;
        int maxid = FootballEntities.GetContext().Date_Location.Max(u => u.id_match);
        public AddEditPageDateLoc(Date_Location selectedDateLoc)
        {
                InitializeComponent();

                if (selectedDateLoc != null) { 
                    _currentDateLoc = selectedDateLoc;
                reg = 1;
            }
            else
            {
                _currentDateLoc.id_match = maxid + 10;
            }


            DataContext = _currentDateLoc;
            }

            private void BtnSave_Click(object sender, RoutedEventArgs e)
            {
                StringBuilder errors = new StringBuilder();

                
                if (string.IsNullOrWhiteSpace(_currentDateLoc.Date_time.ToString()))
                    errors.AppendLine("Укажите дату-время");
                if (string.IsNullOrWhiteSpace(_currentDateLoc.Name_tournament.ToString()))
                    errors.AppendLine("Укажите название турнира");
                if (string.IsNullOrWhiteSpace(_currentDateLoc.id_stadium.ToString()))
                    errors.AppendLine("Укажите номер стадиона");
            if (reg == 0) FootballEntities.GetContext().Date_Location.Add(_currentDateLoc);
            else
            {
                var foot = FootballEntities.GetContext().Date_Location.Where(b => b.id_match == _currentDateLoc.id_match).FirstOrDefault();
                foot.Date_time = _currentDateLoc.Date_time;
                foot.Name_tournament = _currentDateLoc.Name_tournament;
                foot.id_stadium = _currentDateLoc.id_stadium;
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
                _currentDateLoc = new Date_Location();
                        this.Visibility = Visibility.Hidden;
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    

