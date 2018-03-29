using PHD_Kamelott.Models;
using PHD_Kamelott.ViewModels;
using Plugin.Share;
using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PHD_Kamelott.Resources.ViewModels
{
    class DetailPageViewModel:BaseViewModels
    {
        private INavigation Navigation;
        private Sample _mySample;
        public Sample MySample
        {
            get => _mySample;
            set
            {
                _mySample = value;
                OnPropertyChanged();
            }
        }

        public DetailPageViewModel(INavigation navigation, Sample sample)
        {
            
            MySample = sample;
            Navigation = navigation;

            //Title = "Detail sample";
            //Title = sample.Episode;

            PlaySampleCommand = new Command(async()=> await ExecutePlaySampleCommand());
            PlayTextToSpeech = new Command(async () => await ExecuteTextToSpeech());
            ShareSample = new Command(ExecuteShareSample);

        }
        public Command PlaySampleCommand { get; set; }
        public Command PlayTextToSpeech { get; set; }

        public Command ShareSample { get; set; }

        private async Task ExecuteTextToSpeech()
        {
            await CrossTextToSpeech.Current.Speak(MySample.TitleSample);
        }

        private void ExecuteShareSample()
        {
            if (!CrossShare.IsSupported)
                return;

            CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage { Title = "Partager", Text = "Choisissez"});
        }

        private async Task ExecutePlaySampleCommand()
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    var sample = MySample;
                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    var stream = Ressources.GetSampleStreamFromRessources(sample.File);
                    if (stream != null)
                    {
                        player.Load(stream);
                        player.Play();
                    }

                });
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
