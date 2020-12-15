using app;
using DentiSmart.View.AccessApp;
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
    public partial class MenuView : MasterDetailPage
    {
        public MenuView()
        {
            InitializeComponent();
            MyMenu();

        }
        public void MyMenu()
        {
            Detail = new NavigationPage(new Doctor());
            List<Menu> menu = new List<Menu>
            {
                new Menu{ Page= new Historial(),MenuTitle="Mi Perfil",  MenuDetail="Mi perfil",icon="user.png"},
                new Menu{ Page= new CitaView(),MenuTitle="Historial Citas",  MenuDetail="Historial",icon="date.png"},
                new Menu{ Page= new Doctor(),MenuTitle="Doctores",  MenuDetail="Docs",icon="docs.png"},
                new Menu{ Page= new Servicios(),MenuTitle="Servicios",  MenuDetail="Servicios",icon="servicios.png"},
                new Menu{ Page= new LoginPage(),MenuTitle="Cerrar sesion",  MenuDetail="Cerrar",icon="salir.png"}
            };
            ListMenu.ItemsSource = menu;
        }
        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }
        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }
            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
    }
}