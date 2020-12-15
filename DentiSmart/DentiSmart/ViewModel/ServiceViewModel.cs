using DentiSmart.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DentiSmart.ViewModel
{
    public class ServiceViewModel
    {
        public Command SaveServiceCommand { get; set; }
        public Command DeleteServiceCommand { get; set; }

        public Service NewService { get; set; }
        private INavigation Navigation;


        public ServiceViewModel(INavigation navigation)
        {
            NewService = new Service();
            SaveServiceCommand = new Command(async () => await SaveService());
            DeleteServiceCommand = new Command(async () => await DeleteService());

            Navigation = navigation;
        }

        public ServiceViewModel(INavigation navigation, Service service)
        {
            NewService = service;
            SaveServiceCommand = new Command(async () => await SaveService());
            DeleteServiceCommand = new Command(async () => await DeleteService());
            Navigation = navigation;
        }

        public async Task SaveService()
        {
            await App.Database.SaveServiceAsync(NewService);
            await Navigation.PopToRootAsync();
        }

        public async Task DeleteService()
        {
           
                await App.Database.DeleteServiceAsync(NewService);
                await Navigation.PopToRootAsync();

        }
    }

}
