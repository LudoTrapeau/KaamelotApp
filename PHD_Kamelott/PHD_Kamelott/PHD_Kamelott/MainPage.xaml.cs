using PHD_Kamelott.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PHD_Kamelott
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
			
            BindingContext = new MainPageViewModel(Navigation);

		}
	}
}
