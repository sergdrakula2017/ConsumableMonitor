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
using System.Windows;
using ConsumableMonitor.App.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App.Views
{
    /// <summary>
    /// Логика взаимодействия для AddNewConsumableModelView.xaml
    /// </summary>
    public partial class AddNewConsumableModelView : Window
    {
        public AddNewConsumableModelView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<AddNewConsumableModelViewModel>();

        }
    }
}
