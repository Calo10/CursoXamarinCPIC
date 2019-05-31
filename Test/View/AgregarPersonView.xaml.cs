using System;
using System.Collections.Generic;
using Test.ViewModel;
using Xamarin.Forms;

namespace Test.View
{
    public partial class AgregarPersonView : ContentPage
    {
        public AgregarPersonView()
        {
            InitializeComponent();

            BindingContext = PersonViewModel.GetInstance();
        }
    }
}
