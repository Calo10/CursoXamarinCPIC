using System;
using System.Collections.Generic;
using Test.ViewModel;
using Xamarin.Forms;

namespace Test.View
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            BindingContext = LoginViewModel.GetInstance();
        }
    }
}
