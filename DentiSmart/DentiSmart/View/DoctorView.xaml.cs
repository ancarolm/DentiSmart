using DentiSmart.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DentiSmart.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorView : ContentPage
    {
        public DoctorView()
        {
            InitializeComponent();

            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new DoctorListViewModel(Navigation);
        }
    }
}