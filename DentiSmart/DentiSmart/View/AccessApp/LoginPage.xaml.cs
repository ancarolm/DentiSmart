﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Prueba.ViewModel;

namespace Prueba.Views.AccessApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }


        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

    }
}
