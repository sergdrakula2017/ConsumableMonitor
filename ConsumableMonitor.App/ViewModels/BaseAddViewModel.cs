using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using ConsumableMonitor.App.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

namespace ConsumableMonitor.App.ViewModels;

public abstract class BaseAddViewModel<T> : ObservableObject
{
    protected readonly HttpClient HttpClient;

    protected BaseAddViewModel(HttpClient httpClient)
    {
        HttpClient = httpClient;
        SendCommand = new AsyncRelayCommand<Window>(SendExec, CanSend);
        CancelCommand = new AsyncRelayCommand<Window>(CancelExec);
    }

    private static Task CancelExec(Window? window)
    {
        window?.Hide();
        return Task.CompletedTask;
    }

    public IRelayCommand SendCommand { get; }
    public IRelayCommand CancelCommand { get; }
    public abstract string Address { get; set; }

    public abstract bool CanSend(Window? window);
    public abstract T GetValue();

    public virtual async Task SendExec(Window? window)
    { 
        await HttpClient.PostAsJsonAsync(Address, GetValue());
        await CancelExec(window);
    }

}