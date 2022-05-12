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
    /// Логика взаимодействия для Strikers_Page1.xaml
    /// </summary>
    public partial class Strikers_Page1 : Page
    {
        public Strikers_Page1()
        {
            InitializeComponent();
            DGridStrikers.ItemsSource = FootballEntities.GetContext().Top_Scorer5().ToList();
        }
    }
}
