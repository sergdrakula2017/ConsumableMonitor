using System.Windows;
using System.Windows.Navigation;
using ConsumableMonitor.App.Views;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace ConsumableMonitor.App;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Content = Ioc.Default.GetRequiredService<ServerConnectionCheckerView>();
        //*****
        NavigationWindow win = new();
        win.Content = new MainWindowView();
        win.ShowDialog();
        //*****
    }
}