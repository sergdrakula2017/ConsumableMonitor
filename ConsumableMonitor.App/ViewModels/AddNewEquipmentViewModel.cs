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

internal class AddNewEquipmentViewModel : BaseAddViewModel<Equipment>
{
    private string _model = string.Empty;
    private string _producer = string.Empty;
    private string _serialNumber = string.Empty;
    private decimal _cost;

    private int modelId;
    public AddNewEquipmentViewModel(HttpClient httpClient) : base(httpClient) { }
    public override string Address { get; set; } = "api/Equipments";

    public string Producer
    {
        get => _producer;
        set
        {
            SetProperty(ref _producer, value, nameof(Producer));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public string Model
    {
        get => _model;
        set
        {
            SetProperty(ref _model, value, nameof(Model));
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

    public override bool CanSend(Window? window) => !string.IsNullOrWhiteSpace(Producer) && !string.IsNullOrWhiteSpace(Model)&&!string.IsNullOrWhiteSpace(SerialNumber);

    public override Equipment GetValue() => new()
    {
        Alias = string.Empty,
        ModelId = modelId,
        Cost =Cost,
        Scrapped = false,
        Description = string.Empty,
        SerialNumber = SerialNumber,
    };
    
    public override async Task SendExec(Window? window)
    {
        EquipmentModel[]? models = await HttpClient.GetFromJsonAsync<EquipmentModel[]>("api/EquipmentModels");
        EquipmentModel? model = models.FirstOrDefault(x => x.Producer == Producer && x.Model == Model);
        if (model is null)
        {
            HttpResponseMessage result = await HttpClient.PostAsJsonAsync("api/EquipmentModels",
                new EquipmentModel
                {
                    Model = Model,
                    Producer = Producer,
                    Equipments = new List<Equipment>(),
                    SlotDescriptors = new List<EquipmentSlotDescriptor>(),
                    Id = 0                    

                });
            modelId = (await HttpClient.GetFromJsonAsync<EquipmentModel>(result.Headers.Location)).Id;
        }
        else
        {
            modelId = model.Id;
        }
        await base.SendExec(window);
    }
}