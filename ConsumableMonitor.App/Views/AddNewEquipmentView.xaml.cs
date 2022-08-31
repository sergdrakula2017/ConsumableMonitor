using System.Windows;
using ConsumableMonitor.App.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App.Views;

/// <summary>
///     Логика взаимодействия для AddNewEquipmentView.xaml
/// </summary>
public partial class AddNewEquipmentView : Window
{
    public AddNewEquipmentView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<AddNewEquipmentViewModel>();
    }
}