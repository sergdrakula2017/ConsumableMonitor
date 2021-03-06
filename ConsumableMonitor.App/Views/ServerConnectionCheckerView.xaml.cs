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
using ConsumableMonitor.App.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App.Views
{
    /// <summary>
    /// Логика взаимодействия для ServerConnectionCheckerView.xaml
    /// </summary>
    public partial class ServerConnectionCheckerView : UserControl
    {
        public ServerConnectionCheckerView()
        {
            DataContext = Ioc.Default.GetRequiredService<ServerConnectionCheckerViewModel>();
            InitializeComponent();
        }
    }
}
