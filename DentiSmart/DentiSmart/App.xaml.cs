using DentiSmart.Data;
using DentiSmart.Services;
using DentiSmart.View;
using DentiSmart.Views.AccessApp;
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
        #region Database
        static DatabaseQuerys database;

        public static DatabaseQuerys Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseQuerys(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBname.db"));
                }
                return database;
            }
        }
        #endregion

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RegisterPage());

        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
