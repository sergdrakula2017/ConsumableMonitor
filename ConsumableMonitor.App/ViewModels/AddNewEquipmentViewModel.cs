using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using ConsumableMonitor.Models;

namespace ConsumableMonitor.App.ViewModels;

internal class AddNewEquipmentViewModel : BaseAddViewModel<Equipment>
{
    private string _model = string.Empty;
    private string _producer = string.Empty;

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

    public override bool CanSend() => !string.IsNullOrWhiteSpace(Producer) && !string.IsNullOrWhiteSpace(Model);

    public override Equipment GetValue() => new()
    {
        Alias = string.Empty,
        ModelId = modelId,
        Cost = 0,
        Scrapped = false,
        Description = string.Empty,
        SerialNumber = string.Empty,
    };

    public override async Task SendExec()
    {
        HttpResponseMessage result = await HttpClient.PostAsJsonAsync(Address,
            JsonSerializer.Serialize(new EquipmentModel
            {
                Model = Model,
                Producer = Producer,
            }));

        modelId = (await HttpClient.GetFromJsonAsync<EquipmentModel>(result.Headers.Location)).Id;
        await base.SendExec();
    }
}