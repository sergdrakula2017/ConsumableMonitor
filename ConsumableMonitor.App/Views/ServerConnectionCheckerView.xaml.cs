using System.Windows.Controls;
using ConsumableMonitor.App.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App.Views;

/// <summary>
///     Логика взаимодействия для ServerConnectionCheckerView.xaml
/// </summary>
public partial class ServerConnectionCheckerView : UserControl
{
    public ServerConnectionCheckerView()
    {
        DataContext = Ioc.Default.GetRequiredService<ServerConnectionCheckerViewModel>();
        InitializeComponent();
    }
}