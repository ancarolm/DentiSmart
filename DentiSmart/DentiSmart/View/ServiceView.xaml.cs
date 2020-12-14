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
    public partial class ServiceView : ContentPage
    {
        public ServiceView(Service service = null)
        {
            InitializeComponent();

            if (service == null)
            {
                BindingContext = new ServiceViewModel(Navigation);
            }
            else
            {
                BindingContext = new ServiceViewModel(Navigation, service);
            }
        }
    }
}