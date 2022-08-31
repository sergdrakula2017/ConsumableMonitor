using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using ConsumableMonitor.Models;
using Microsoft.Extensions.Primitives;
using NuGet.DependencyResolver;
using System.Collections.ObjectModel;
using ConsumableMonitor.App.Views;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

namespace ConsumableMonitor.App.ViewModels;

internal class AddNewConsumableViewModel : BaseAddViewModel<Consumable> 
{
    private ConsumableModel _model ;
    private int    _installedInEquipmentId;
    private int    _installedInNumber;
    private int _familyId;
    private int    modelId;
    private string _serialNumber = string.Empty;
    private string _alias = string.Empty;
    private string _description =string.Empty;
    private decimal _cost;
    private string _producer = string.Empty;

    // private int _installedIn;
    private readonly HttpClient _httpClient;

    public AddNewConsumableViewModel(HttpClient httpClient) : base(httpClient)
   {
       _httpClient = httpClient;
       Task load = new Task(async () => await GetData());
       load.RunSynchronously();
       AddNewConsumableModel = new AsyncRelayCommand(AddNewCOnsumableModelExec);
   }

    public IRelayCommand AddNewConsumableModel { get; }

    public async Task GetData()
    {
        ConsumableModels.Clear();
        var array = await _httpClient.GetFromJsonAsync<ConsumableModel[]>("api/ConsumableModels");
        foreach (ConsumableModel consumableModel in array)
        {
            ConsumableModels.Add(consumableModel);//-
            
        }
    }

    public async Task AddNewCOnsumableModelExec()//
    {
        Ioc.Default.GetRequiredService<AddNewConsumableModelView>().ShowDialog();
        await GetData();
    }


    public ObservableCollection<ConsumableModel> ConsumableModels { get; } = new ObservableCollection<ConsumableModel>();

    public override string Address { get; set; } = "api/Consumables";

    public ConsumableModel Model
    {
        get => _model;
        set
        {
            SetProperty(ref _model, value,nameof(Model));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public string SerialNumber
    {
        get => _serialNumber;
        set
        {
            SetProperty(ref _serialNumber, value, nameof(SerialNumber));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public decimal Cost
    {
        get => _cost;
        set
        {
            SetProperty(ref _cost, value, nameof(Cost));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public string Description 
    { get => _description;
      set
        {
            SetProperty( ref _description, value, nameof(Description));
            SendCommand.NotifyCanExecuteChanged();

        }
    }

    public string Alias
    {
        get => _alias;
        set
        {
            SetProperty(ref _alias, value, nameof(Alias));
            SendCommand?.NotifyCanExecuteChanged();
        }
    }

    public string Producer
    {
        get => _producer;
        set
        {
            SetProperty(ref _producer, value, nameof(Producer));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public int FamilyId
    {
        get => _familyId;
        set
        {
            SetProperty(ref _familyId, value, nameof(FamilyId));
            SendCommand.NotifyCanExecuteChanged();
        }
    }
    //--220513
    public int InstalledInEquipmentId
    {
        get => _installedInEquipmentId;
        set
        {
            SetProperty(ref _installedInEquipmentId, value, nameof(InstalledInEquipmentId));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public int InstalledInNumber
    {
        get => _installedInNumber;
        set
        {
            SetProperty(ref _installedInNumber, value, nameof(InstalledInNumber));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

   /* public int InstalledIn
    {
        get => _installedIn;
        set
        {
            SetProperty(ref _installedIn, value, nameof(InstalledIn));
            SendCommand.NotifyCanExecuteChanged();
        }
    }*/

    public override bool CanSend(Window? window) => Model is not null && !string.IsNullOrWhiteSpace(SerialNumber);
    public override Consumable GetValue() => new()
    {
        Alias = Alias,
        ModelId = modelId,
        Cost = Cost,
        Scrapped = false,
        Description = Description,
        SerialNumber = SerialNumber,
        InstalledInEquipmentId = null,
        InstalledInNumber = null,
        //InstalledIn  = InstalledIn,
        
    };

    public override async Task SendExec(Window? window)
    {
       
        
        
            modelId = Model.Id;
        



        await base.SendExec(window);
    }
}