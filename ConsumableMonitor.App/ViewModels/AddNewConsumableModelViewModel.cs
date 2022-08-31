using System;
using System.Collections.Concurrent;
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
namespace ConsumableMonitor.App.ViewModels
{

    internal class AddNewConsumableModelViewModel : BaseAddViewModel<ConsumableModel>
    {
        private readonly HttpClient _httpClient;
        private string _model = string.Empty;
        private string _producer = string.Empty;
        //private int modelId;
        public override string Address { get; set; } = "api/ConsumableModels";

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

        public AddNewConsumableModelViewModel(HttpClient httpClient) : base(httpClient)
        {

        }
        public override ConsumableModel GetValue() => new()
        {
           Model = Model,
           Producer = Producer,

        };
        public override bool CanSend(Window? window) => !string.IsNullOrWhiteSpace(Producer) && !string.IsNullOrWhiteSpace(Model);


        public override async Task SendExec(Window? window)
        {
            var family = await HttpClient.PostAsJsonAsync("api/ConsumableModelFamilies", new ConsumableModelFamily() {  });
            ConsumableModel[]? models = await HttpClient.GetFromJsonAsync<ConsumableModel[]>("api/ConsumableModels");
            ConsumableModel? model = models.FirstOrDefault(x => x.Producer == Producer && x.Model == Model);
            if (model is null)
            {
                var F = await family.Content.ReadFromJsonAsync<ConsumableModelFamily>();
                HttpResponseMessage result = await HttpClient.PostAsJsonAsync("api/ConsumableModels",
                    new ConsumableModel
                    {
                        Model = Model,
                        Producer = Producer,
                        FamilyId = F.Id,

                    });
                //modelId = (await HttpClient.GetFromJsonAsync<ConsumableModel>(result.Headers.Location)).Id;
            }
            else
            {
               // modelId = model.Id;
            }



            await base.SendExec(window);
        }


    }
}
