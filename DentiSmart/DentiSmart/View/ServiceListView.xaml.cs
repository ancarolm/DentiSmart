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
    public partial class ServiceListView : ContentPage
    {
        public ServiceListView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new ServiceListViewModel(Navigation);
        }
    }
}