﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using DentiSmart.Model;
using DentiSmart.View;

using Xamarin.Forms;

namespace DentiSmart.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attribute
        public string email;
        public string password;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }


        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
        }
        #endregion

        #region Methods


        public async void LoginMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Tiene que agregar un correo.",
                    "Aceptar");
                return;
            }

            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(20);



            List<UserModel> e = App.Database.GetUsersValidate(email, password).Result;

            if (e.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                  "Error",
                  "Contraseña o correo incorrectos.",
                  "Aceptar");

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
            else if (e.Count > 0)
            {
                
                await Application.Current.MainPage.Navigation.PushAsync(new ServiceListView());

                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;

            }
        }


            #endregion

            #region Constructor
            public LoginViewModel()
            {
                this.IsEnabledTxt = true;
            }
            #endregion
        }
    }

