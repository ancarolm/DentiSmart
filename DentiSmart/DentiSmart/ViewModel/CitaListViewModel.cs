using app;
using DentiSmart.Model;
using DentiSmart.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DentiSmart.ViewModel
{
    public class CitaListViewModel
    {
        public IList<CitaView> Citas { get; set; }
        public Command AddCitaCommand { get; set; }
        public Command BackHomeCommand { get; set; }
        private INavigation Navigation;
        private Cita _currentCita;
        public Command ItemTappedCommand { get; set; }
        
        public Cita CurrentCita
        {
            get { return _currentCita; }
            set
            {
                _currentCita = value;
                OnPropertyChanged();
            }
        }

        public CitaListViewModel(INavigation navigation)
        {
            CitaRepository repository = new CitaRepository();
            Citas = repository.GetAll();
            Navigation = navigation;
            AddCitaCommand = new Command(async () => await NavigateToCitaView());
            ItemTappedCommand = new Command(async () => await NavigateToEditCitaView());
            BackHomeCommand = new Command(async () => await NavigateToHomeView());

        }

        public async Task NavigateToCitaView()
        {
            await Navigation.PushAsync(new CitaView());
        }

        public async Task NavigateToHomeView()
        {
            await Navigation.PushAsync(new CitaView());
        }

        public async Task NavigateToEditCitaView()
        {
           await Navigation.PushAsync(new CitaView(CurrentCita));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    
}
