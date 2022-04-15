using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ConsumableMonitor.App.Views;
using ConsumableMonitor.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

namespace ConsumableMonitor.App.ViewModels;

internal class MainWindowViewModel : ObservableObject
{
    private readonly HttpClient _httpClient;
    private Equipment? _selectedEquipment;

    public MainWindowViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        AddEquipment = new AsyncRelayCommand(AddEquipmentExec);
        RemoveEquipment = new AsyncRelayCommand(RemoveEquipmentExec, RemoveEquipmentCanExec);
        Equipments = new();
        Consumables = new();
        _ = GetData();
    }

    public IRelayCommand AddEquipment { get; }
    public IRelayCommand RemoveEquipment { get; }

    public Equipment? SelectedEquipment
    {
        get => _selectedEquipment;
        set
        {
            SetProperty(ref _selectedEquipment, value, nameof(SelectedEquipment));
            RemoveEquipment.NotifyCanExecuteChanged();
        }
    }

    public ObservableCollection<Equipment> Equipments { get; }
    public ObservableCollection<Consumable> Consumables { get; }

    public async Task GetData()
    {
        Equipments.Clear();
        foreach (Equipment equipment in await _httpClient.GetFromJsonAsync<Equipment[]>("api/Equipments")) Equipments.Add(equipment);
        Equipments.Clear();
        foreach (Consumable consumable in await _httpClient.GetFromJsonAsync<Consumable[]>("api/Consumables")) Consumables.Add(consumable);
    }

    public async Task AddEquipmentExec()
    {
        Ioc.Default.GetRequiredService<AddNewEquipmentView>().ShowDialog();
        await GetData();
    }

    public bool RemoveEquipmentCanExec() => SelectedEquipment is not null;

    public async Task RemoveEquipmentExec()
    {
        await _httpClient.DeleteAsync($"api/Equipments/{SelectedEquipment!.Id}");
        
    }
}