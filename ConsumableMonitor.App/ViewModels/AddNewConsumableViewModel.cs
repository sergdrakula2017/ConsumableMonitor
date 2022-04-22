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

namespace ConsumableMonitor.App.ViewModels;

internal class AddNewConsumableViewModel : BaseAddViewModel<Consumable> 
{
    private string _model = string.Empty;
    private int    _installedInEquipmentId;
    private int    _installedInNumber;
    private int _familyId;
    private int    modelId;
    private string _serialNumber = string.Empty;
    private string _alias = string.Empty;
    private string _description =string.Empty;
    private decimal _cost;
    private string _producer = string.Empty;

    public AddNewConsumableViewModel(HttpClient httpClient) : base(httpClient) { }
    public override string Address { get; set; } = "api/Consumables";

    public string Model
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

    public int FamiliId
    {
        get => _familyId;
        set
        {
            SetProperty(ref _familyId, value, nameof(FamiliId));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public override bool CanSend(Window? window) => !string.IsNullOrWhiteSpace(Model) && !string.IsNullOrWhiteSpace(SerialNumber);
    public override Consumable GetValue() => new()
    {
        Alias = Alias,
        ModelId = modelId,
        Cost = Cost,
        Scrapped = false,
        Description = Description,
        SerialNumber = SerialNumber,
        
    };

    public override async Task SendExec(Window? window)
    {
        ConsumableModel[]? models = await HttpClient.GetFromJsonAsync<ConsumableModel[]>("api/ConsumableModels");
        ConsumableModel? model = models.FirstOrDefault(x => x.Model == Model);
        if (model is null)
        {
            HttpResponseMessage result = await HttpClient.PostAsJsonAsync("api/ConsumableModels",
                new ConsumableModel
                {
                    Model = Model,
                    Producer = Producer,
                    SupportedSlotDescriptors = new List<EquipmentSlotDescriptor>(),
                    Consumables = new List<Consumable>(),
                    FamilyId =FamiliId,
                    Id = 0
                });
            modelId = (await HttpClient.GetFromJsonAsync<ConsumableModel>(result.Headers.Location)).Id;

        }
        else
        {
            modelId = model.Id;
        }

        await base.SendExec(window);
    }
}