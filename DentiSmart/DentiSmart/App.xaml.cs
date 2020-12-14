﻿using DentiSmart.Data;
using DentiSmart.Services;
using DentiSmart.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DentiSmart
{
    public partial class App : Application
    {
        private static DentistDatabase database;

        public static DentistDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DentistDatabase(DependencyService.Get<IfileHelper>().GetLocalFilePath("dentistdb.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ServiceListView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
