using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var aqui = new Models.Personas
            {
                Nombre = nombres.Text,
                Apellidos = apellidos.Text,
                Edad = int.Parse(edad.Text),
                Correo = correo.Text,
                Direccion = direccion.Text

            };

            if (await App.dbPersonas.storeEquipo(aqui) > 0)
            {
                nombres.Text = "";
                apellidos.Text = "";
                edad.Text = "";
                correo.Text = "";
                direccion.Text = "";
                await DisplayAlert("Aviso", "Datos Guardado con exito", "OK");

            }
            else
            {
                await DisplayAlert("Error", "Datos no se Guardaron", "OK");
            }
        }
    }
}
