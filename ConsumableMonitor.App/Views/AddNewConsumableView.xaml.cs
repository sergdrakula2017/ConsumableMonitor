using System.Windows;
using ConsumableMonitor.App.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App.Views;

/// <summary>
///     Логика взаимодействия для AddNewConsumableView.xaml
/// </summary>
public partial class AddNewConsumableView : Window
{
    public AddNewConsumableView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<AddNewConsumableViewModel>();
    }
}