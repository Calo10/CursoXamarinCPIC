using System;
using System.Collections.Generic;
using Test.ViewModel;
using Xamarin.Forms;

namespace Test.View
{
    public partial class PersonView : ContentPage
    {
        public PersonView()
        {
            InitializeComponent();

            BindingContext = new PersonViewModel();
        }
    }
}
