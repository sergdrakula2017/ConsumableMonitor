using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace ConsumableMonitor.App.ViewModels;

public abstract class BaseAddViewModel<T> : ObservableObject
{
    protected readonly HttpClient HttpClient;

    protected BaseAddViewModel(HttpClient httpClient)
    {
        HttpClient = httpClient;
        SendCommand = new AsyncRelayCommand(SendExec, CanSend);
    }

    public IRelayCommand SendCommand { get; }
    public abstract string Address { get; set; }

    public abstract bool CanSend();
    public abstract T GetValue();

    public virtual async Task SendExec()
    {
        await HttpClient.PostAsJsonAsync(Address, JsonSerializer.Serialize(GetValue()));
    }
}