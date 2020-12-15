using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Prueba.ViewModel;

namespace Prueba.Views.AccessApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
            
        }


        private async void NavToLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
