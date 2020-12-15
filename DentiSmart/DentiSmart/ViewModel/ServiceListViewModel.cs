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
    public class ServiceListViewModel : INotifyPropertyChanged
    {
        public IList<Service> Services { get; set; }
        public Command AddServiceCommand { get; set; }
        public Command BackHomeCommand { get; set; }
        private INavigation Navigation;
        private Service _currentService;
        public Command ItemTappedCommand { get; set; }

        public Service CurrentService
        {
            get { return _currentService; }
            set
            {
                _currentService = value;
                OnPropertyChanged();
            }
        }

        public ServiceListViewModel(INavigation navigation)
        {
            ServiceRepository repository = new ServiceRepository();
            Services = repository.GetAll();
            Navigation = navigation;
            AddServiceCommand = new Command(async () => await NavigateToServiceView());
            ItemTappedCommand = new Command(async () => await NavigateToEditServiceView());
            BackHomeCommand = new Command(async () => await NavigateToHomeView());

        }

        public async Task NavigateToServiceView()
        {
            await Navigation.PushAsync(new ServiceView());
        }

        public async Task NavigateToHomeView()
        {
            await Navigation.PushAsync(new DoctorView());
        }

        public async Task NavigateToEditServiceView()
        {
            await Navigation.PushAsync(new ServiceView(CurrentService));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
