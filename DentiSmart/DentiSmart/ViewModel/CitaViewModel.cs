using DentiSmart.Model;
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
    public class CitaViewModel
    {
        public Command SaveCitaCommand { get; set; }
        public Model.Cita NewCita { get; set; }
        private INavigation Navigation;

        public CitaViewModel(INavigation navigation)
        {
            NewCita = new Model.Cita();
            SaveCitaCommand = new Command(async () => await SaveCita());
            Navigation = navigation; ;

        }

        public CitaViewModel(INavigation navigation, Model.Cita cita)
        {
            NewCita = cita;
            SaveCitaCommand = new Command(async () => await SaveCita());
            Navigation = navigation;
        }

        public async Task SaveCita()
        {
            await App.Database.SaveCitaAsync(NewCita);
            await Navigation.PopToRootAsync();
        }
    }
}
