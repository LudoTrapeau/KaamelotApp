using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHD_Kamelott.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMDMaster : ContentPage
    {
        public ListView ListView;

        public MyMDMaster()
        {
            InitializeComponent();

            BindingContext = new MyMDMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyMDMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyMDMenuItem> MenuItems { get; set; }
            
            public MyMDMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyMDMenuItem>(new[]
                {
                    new MyMDMenuItem { Id = 0, Title = "Page 1", TargetType= typeof(MainPage) },
                    new MyMDMenuItem { Id = 1, Title = "Page 2" },
                    new MyMDMenuItem { Id = 2, Title = "Page 3" },
                    new MyMDMenuItem { Id = 3, Title = "Page 4" },
                    new MyMDMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}