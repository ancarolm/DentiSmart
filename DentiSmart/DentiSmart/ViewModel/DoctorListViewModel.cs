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
    class DoctorListViewModel : INotifyPropertyChanged
    {
        public IList<Doctor> Doctors { get; set; }
        public Command AddDoctorCommand { get; set; }
        public Command BackHomeCommand { get; set; }
        private INavigation Navigation;
        private Doctor _currentDoctor;
        public Command ItemTappedCommand { get; set; }

        public Doctor CurrentDoctor
        {
            get { return _currentDoctor; }
            set
            {
                _currentDoctor = value;
                OnPropertyChanged();
            }
        }

        public DoctorListViewModel(INavigation navigation)
        {
            DoctorRepository repository = new DoctorRepository();
            Doctors = repository.GetAll();
            Navigation = navigation;
            AddDoctorCommand = new Command(async () => await NavigateToDoctorView());
            ItemTappedCommand = new Command(async () => await NavigateToEditDoctorView());
            BackHomeCommand = new Command(async () => await NavigateToHomeView());
        }

        public async Task NavigateToDoctorView()
        {
            await Navigation.PushAsync(new DoctorAddView());
        }

        public async Task NavigateToHomeView()
        {
            await Navigation.PushAsync(new ServiceListView());
        }

        public async Task NavigateToEditDoctorView()
        {
            await Navigation.PushAsync(new DoctorAddView(CurrentDoctor));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
