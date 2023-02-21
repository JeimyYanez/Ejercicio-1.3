using Ejercicio3.Controllers;
using Ejercicio3.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3
{
    public partial class App : Application
    {

        static Controllers.PersonasDB dbpersonas;

        public static Controllers.PersonasDB dbPersonas
        {

            get
            {
                if (dbpersonas == null)
                {
                    var Pathapp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    var DBName = Models.Configuraciones.DBName;
                    var PathFull = Path.Combine(Pathapp, DBName);
                    dbpersonas = new Controllers.PersonasDB(PathFull);
                }

                return dbpersonas;

            }
        }




        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PageLista());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
