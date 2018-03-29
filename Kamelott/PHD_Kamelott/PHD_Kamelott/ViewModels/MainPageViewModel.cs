using Newtonsoft.Json;
using PHD_Kamelott.Models;
using PHD_Kamelott.Resources;
using PHD_Kamelott.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PHD_Kamelott.ViewModels
{

    public class MainPageViewModel : BaseViewModels
    {
        private INavigation Navigation;
        private List<Sample> _samples;
        public List<Sample> Samples
        {
            get => _samples;
            set
            {
                _samples = value;
                OnPropertyChanged(nameof(Samples));
            }
        }


        public Command GotoDetailCommand { get; set; }
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            try
            {
                string jsonBrut = Resources.Ressources.GetJSONFromRessources("sounds.json");
                Samples = JsonConvert.DeserializeObject<List<Sample>>(jsonBrut);

                //PlaySampleCommand = new Command(async (object obj) =>
                //{
                //    await ExecutePlaySampleCommand(obj);
                //});

                GotoDetailCommand = new Command(async (object obj) =>
                {
                    await ExecuteGoToDetailCommand(obj);
                }
                    );

                RefreshSampleCommand = new Command(async (object obj) =>
                {
                    await ExecuteRefreshSampleCommand();
                }
                );
                RefreshSampleCommand.Execute(null);
            }
            catch (Exception ex)
            {

            }
            //Title = "La liste des samples";


        }

        private async Task ExecuteGoToDetailCommand(object param)
        {
            var sample = (Sample)param;
            await Navigation.PushAsync(new DetailPage(sample));
        }

        public Command RefreshSampleCommand { get; set; }

        private async Task ExecuteRefreshSampleCommand()
        {
            IsBusy = true;
            string jsonbrut = Resources.Ressources.GetJSONFromRessources("sounds.json");
            Samples = JsonConvert.DeserializeObject<List<Sample>>(jsonbrut);
            IsBusy = false;

        }

    }

}
