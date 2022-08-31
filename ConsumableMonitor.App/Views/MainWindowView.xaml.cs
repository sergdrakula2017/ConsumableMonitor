using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ConsumableMonitor.App.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App.Views;

/// <summary>
///     Логика взаимодействия для MainWindowView.xaml
/// </summary>
public partial class MainWindowView : Window
{
    public MainWindowView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
    }

}