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
<<<<<<< Updated upstream
using System.Windows.Shapes;

=======
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsumableMonitor.App.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
namespace ConsumableMonitor.App.Views;
>>>>>>> Stashed changes

namespace ConsumableMonitor.App.Views
{
    /// <summary>
    /// Логика взаимодействия для AddData.xaml
    /// </summary>
    public partial class AddData : Window
    {
<<<<<<< Updated upstream
        public AddData()
        {
            InitializeComponent();
        }

       
=======
        InitializeComponent();
        DataContext = new AddDataViewModel();
>>>>>>> Stashed changes

    }
}
