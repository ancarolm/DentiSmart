﻿using DentiSmart.Model;
using DentiSmart.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentiSmart.ViewModel
{
    public class DoctorViewModel 
    {
        public Command SaveDoctorCommand { get; set; }
        public Model.Doctor NewDoctor { get; set; }
        private INavigation Navigation;


        public DoctorViewModel(INavigation navigation)
        {
            NewDoctor = new Model.Doctor();
            SaveDoctorCommand = new Command(async () => await SaveDoctor());
            Navigation = navigation;;

        }

        public DoctorViewModel(INavigation navigation, Model.Doctor doctor)
        {
            NewDoctor = doctor;
            SaveDoctorCommand = new Command(async () => await SaveDoctor());
            Navigation = navigation;
        }

        public async Task SaveDoctor()
        {
            await App.Database.SaveDoctorAsync(NewDoctor);
            await Navigation.PopToRootAsync();
        }
    }
}
