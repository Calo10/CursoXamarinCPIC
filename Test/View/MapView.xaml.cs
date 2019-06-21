using System;
using System.Collections.Generic;
using Test.ViewModel;
using Xamarin.Forms;

namespace Test.View
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();

            BindingContext = MapViewModel.GetInstance();
        }
    }
}
