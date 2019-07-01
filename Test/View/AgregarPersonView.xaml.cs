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

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                imgUserPhoto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }
    }
}
