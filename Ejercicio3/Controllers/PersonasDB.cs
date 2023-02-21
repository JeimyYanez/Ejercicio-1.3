using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Controllers
{
    public class PersonasDB
    {
        readonly SQLite.SQLiteAsyncConnection _conexion;


        public PersonasDB(string dbpath)
        {
            _conexion = new SQLiteAsyncConnection(dbpath);

            //Creacion de objeto para la dba 
            _conexion.CreateTableAsync<Models.Personas>().Wait();
        }


        public Task<int> storeEquipo(Models.Personas personas)
        {
            if (personas.Id == 0)
            {
                return _conexion.InsertAsync(personas);
            }
            else
            {
                return _conexion.UpdateAsync(personas);
            }

        }

        public Task<List<Models.Personas>> ListaPersonas()
        {
            return _conexion.Table<Models.Personas>().ToListAsync();
        }

        public Task<Models.Personas> GetPersonas(int pid)
        {
            return _conexion.Table<Models.Personas>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        public Task<List<Models.Personas>> GetItemsByFirstLetterAsync(char letter)
        {
            return _conexion.Table<Models.Personas>().Where(i => i.Nombre.ToUpper().StartsWith(letter.ToString().ToUpper()))
                             .ToListAsync();
        }


        //Delete forma normal 

        /*  public Task<int> DeletePersonas(Models.Personas personas, int id)
          {
              return _conexion.DeleteAsync(personas);
          }*/

        //Delete Forma ItemMenu
        public Task<int> DeletePersonasItem(Models.Personas personas)
        {
            return _conexion.DeleteAsync(personas);
        }





    }

}
