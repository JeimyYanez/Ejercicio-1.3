using Ejercicio3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLista : ContentPage
    {
        public PageLista()
        {
            InitializeComponent();
        }

        private async void toolAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void ListPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Models.Persona persona = (Models.Persona)e.CurrentSelection.FirstOrDefault();
            Models.Personas perd = new Personas();
            perd = e.CurrentSelection.FirstOrDefault() as Models.Personas ;
            var pag = new PageAcciones();
            pag.BindingContext = perd;
            await Navigation.PushAsync(pag);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListPersonas.ItemsSource = await App.dbPersonas.ListaPersonas();

        }
    }
}