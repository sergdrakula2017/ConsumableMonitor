using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using ConsumableMonitor.App.Enums;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace ConsumableMonitor.App.ViewModels;

public class ServerConnectionCheckerViewModel : ObservableObject
{
    private readonly HttpClient _httpClient;
    private string _connectionUrl = string.Empty;
    private HealthStatus? _status;

    public ServerConnectionCheckerViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        CheckConnection = new AsyncRelayCommand(CheckConnectionExec);
    }

    public HealthStatus? Status
    {
        get => _status;
        set
        {
            SetProperty(ref _status, value, nameof(Status));
            OnPropertyChanged(nameof(StatusString));
        }
    }

    public string StatusString =>
        Status switch
        {
            HealthStatus.Unhealthy => "Не работает",
            HealthStatus.Degraded => "Работает частично",
            HealthStatus.Healthy => "Работает",
            null => "Подключение неудачно или адер неверен",
            _ => throw new ArgumentOutOfRangeException(),
        };

    public ICommand CheckConnection { get; }

    public string ConnectionUrl
    {
        get => _connectionUrl;
        set => SetProperty(ref _connectionUrl, value, nameof(ConnectionUrl));
    }

    public async Task CheckConnectionExec()
    {
        try
        {
            _httpClient.BaseAddress = new(ConnectionUrl);
            string result = await _httpClient.GetStringAsync("/api/health");
            Status = Enum.Parse<HealthStatus>(result);
        }
        catch (HttpRequestException)
        {
            Status = null;
        }
    }
    /*
    private RelayCommand addCommand1;
    public RelayCommand AddCommand1
    {
        get
        {
            return addCommand1 ??
              (addCommand1 = new RelayCommand(ShowAddData));
        }
    }
    public void ShowAddData()
    {
        MainWindowView page1 = new MainWindowView();
        page1.Show();
    }*/
}