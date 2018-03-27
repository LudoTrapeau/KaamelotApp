﻿using PHD_Kamelott.Models;
using PHD_Kamelott.Resources.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHD_Kamelott.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMDDetail : ContentPage
    {
        public MyMDDetail(Sample sample)
        {
            InitializeComponent();
            BindingContext = new DetailPageViewModel(Navigation,sample);
        }
    }
}