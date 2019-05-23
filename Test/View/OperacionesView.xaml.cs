using System;
using System.Collections.Generic;
using Test.ViewModel;
using Xamarin.Forms;

namespace Test.View
{
    public partial class OperacionesView : ContentPage
    {
        public OperacionesView()
        {
            InitializeComponent();

            BindingContext = new OperacionesViewModel();
        }
    }
}
