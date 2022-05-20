using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ConsumableMonitor.App.Views;
using ConsumableMonitor.Models;
using ConsumableMonitor.Server.Controllers;
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
        AddConsumable = new AsyncRelayCommand(AddConsumableExec);
        RemoveEquipment = new AsyncRelayCommand(RemoveEquipmentExec, RemoveEquipmentCanExec);
        Equipments = new();
        EquipmentModels = new();//
        Consumables = new();
        ConsumableModels = new();//-
        ConsumableModelsFamilies = new();
        _ = GetData();
    }

    public IRelayCommand AddEquipment { get; }
    public IRelayCommand AddConsumable { get; }
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

    public ObservableCollection<EquipmentModel> EquipmentModels { get; }//
    
    public ObservableCollection<Consumable> Consumables { get; }
    
    public ObservableCollection<ConsumableModel> ConsumableModels { get; } //-
    public ObservableCollection<ConsumableModelFamily> ConsumableModelsFamilies { get; }//--

    public async Task GetData()
    {
        Equipments.Clear();
        EquipmentModels.Clear(); //
        foreach (EquipmentModel equipmentModel in await _httpClient.GetFromJsonAsync<EquipmentModel[]>("api/EquipmentModels"))      
            EquipmentModels.Add(equipmentModel);
        
        foreach (Equipment equipment in await _httpClient.GetFromJsonAsync<Equipment[]>("api/Equipments")) 
        {
            Equipments.Add(equipment);
            equipment.Model=EquipmentModels.FirstOrDefault(x=>x.Id==equipment.ModelId);
            //equipment.Producer =EquipmentModels.FirstOrDefault();
        }

        ConsumableModelsFamilies.Clear();
        foreach (ConsumableModelFamily consumableModelFamily in await _httpClient.GetFromJsonAsync<ConsumableModelFamily[]>($"api/ConsumableModelFamilies"))
        ConsumableModelsFamilies.Add(consumableModelFamily);
            
        

        ConsumableModels.Clear();
        foreach (ConsumableModel consumableModel in await _httpClient.GetFromJsonAsync<ConsumableModel[]>("api/ConsumableModels")) ConsumableModels.Add(consumableModel);//-

        Consumables.Clear();
        foreach (Consumable consumable in await _httpClient.GetFromJsonAsync<Consumable[]>("api/Consumables"))
        {
            Consumables.Add(consumable);
            consumable.Model=ConsumableModels.FirstOrDefault(x=>x.Id==consumable.ModelId);//-
            
        }
        
        OnPropertyChanged(nameof(Equipments));
        OnPropertyChanged(nameof(Consumables));
        OnPropertyChanged(nameof(EquipmentModels));//
        OnPropertyChanged(nameof(ConsumableModels));//-
        OnPropertyChanged(nameof(ConsumableModelsFamilies));
    }

    public async Task AddEquipmentExec()
    {
        Ioc.Default.GetRequiredService<AddNewEquipmentView>().ShowDialog();
        await GetData(); 
    }

    public async Task AddConsumableExec()//
    {
        Ioc.Default.GetRequiredService<AddNewConsumableView>().ShowDialog();
        await GetData();
    }

    public bool RemoveEquipmentCanExec() => SelectedEquipment is not null;

    public async Task RemoveEquipmentExec()
    {
        await _httpClient.DeleteAsync($"api/Equipments/{SelectedEquipment!.Id}");
        
    }
    private object selectedItem;

    public object SelectedItem
    {
        get { return this.selectedItem; }
        set
        {
            if (value != this.selectedItem)
            {
                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");//считывангие выделенной строки 
            }
        }
    }
}