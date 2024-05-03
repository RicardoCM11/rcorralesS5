
using rcorralesS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rcorralesS5
{
    public class PersonaRepository
    {
        string _dbpath;
        private SQLiteConnection conn;
        public string statusmessage  { get; set; }
    
        private void Init()
        {
            if (conn is not null)
            
                return;
                conn = new(_dbpath);
                conn.CreateTable<Persona>();

        }

        public PersonaRepository(string dbpath)
        {
            _dbpath = dbpath;
        }

        //metodo insertar 
        public void AddNewPersona(string name)
        {
            int result = 0;

            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                    Persona persona = new () { Name = name};
                result = conn.Insert(persona);
                statusmessage = string.Format("Se inserto un persona", result,name);
            }
            catch (Exception ex)
            {

                statusmessage = string.Format("No se pudo insertar",name,ex.Message);
            }
        }


        //metodo listar 
        public List<Persona> GetAllPersona() 
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                statusmessage = string.Format("Error al Listar", ex.Message);
            }
            return new List<Persona>();
        }

        public void DeletePersona(string name)
        {
            int result = 0;

            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");

               
                var personaToDelete = conn.Table<Persona>().FirstOrDefault(p => p.Name == name);
                if (personaToDelete != null)
                {
                    result = conn.Delete(personaToDelete);
                    statusmessage = string.Format("Se eliminó una persona", result, name);
                }
                else
                {
                    statusmessage = "No se encontró la persona para eliminar";
                }
            }
            catch (Exception ex)
            {
                statusmessage = string.Format("No se pudo eliminar", name, ex.Message);
            }
        }

        public List<Persona> ActualizarPersona()
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                statusmessage = string.Format("Error al Listar", ex.Message);
            }
            return new List<Persona>();
        }

    }

}
