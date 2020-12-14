using DentiSmart.Model;
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
    public partial class DoctorAddView : ContentPage
    {
        public DoctorAddView(Doctor doctor = null)
        {
            InitializeComponent();

            if (doctor == null)
            {
                BindingContext = new DoctorViewModel(Navigation);
            }
            else
            {
                BindingContext = new DoctorViewModel(Navigation, doctor);
            }
        }
    }
}