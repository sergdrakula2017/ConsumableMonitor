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
    private string _modelCompability = string.Empty;
    private string _description = string.Empty;
    private string _alias = string.Empty;

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

    

    public string Description
    {
        get => _description;
        set
        {
            SetProperty(ref _description, value, nameof(Description));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public string Alias
    {
        get => _alias;
        set
        {
            SetProperty(ref _alias, value, nameof(Alias));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public string ModelCompability
    {
        get => _modelCompability;
        set
        {
            SetProperty(ref _modelCompability,value, nameof(ModelCompability));
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public override bool CanSend(Window? window) => !string.IsNullOrWhiteSpace(Producer) && !string.IsNullOrWhiteSpace(Model)&&!string.IsNullOrWhiteSpace(SerialNumber)&&!string.IsNullOrWhiteSpace(Alias)&&!string.IsNullOrWhiteSpace(Description);

    public override Equipment GetValue() => new()
    {
        Alias = Alias,
        ModelId = modelId,
        Scrapped = false,
        Description = Description,
        SerialNumber = SerialNumber,        
       
    };
    
    public override async Task SendExec(Window? window)
    {
        EquipmentModel[]? models = await HttpClient.GetFromJsonAsync<EquipmentModel[]>("api/EquipmentModels");
        EquipmentModel? model = models.FirstOrDefault(x => x.Producer == Producer && x.Model == Model && x.ModelCompability==ModelCompability);
        if (model is null)
        {
            HttpResponseMessage result = await HttpClient.PostAsJsonAsync("api/EquipmentModels",
                new EquipmentModel
                {
                    Model = Model,
                    Producer = Producer,
                    ModelCompability = ModelCompability,

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