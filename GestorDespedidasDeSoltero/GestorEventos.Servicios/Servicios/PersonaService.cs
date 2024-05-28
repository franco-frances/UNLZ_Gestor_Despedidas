using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService
    {
        //IENumerable para esstablecer que es una Lista de Entidades
        //public IEnumerable<Persona> PersonasDePrueba { get; set; }
        private string conectionString;

        //constructor
        public PersonaService()
        {
            conectionString = "Server=.\\SQLEXPRESS;Database=master;Integrated Security=True;";





            //PersonasDePrueba = new List<Persona>
            //{
            //    new Persona{ IdPersona = 1, Nombre = "Esteban",Apellido = "Gomez",Direccion = "Moreno 1814",Email = "estebangomez@yopmail.com",Telefono = "1111111",Borrado=true },
            //    new Persona{ IdPersona = 2, Nombre = "Jose", Apellido = "Peñaloza",Direccion = "Alberdi 4456" , Email = "Josepenaloza@yopmail.com", Telefono = "22222222",Borrado=true},
            //    new Persona{ IdPersona = 3, Nombre = "Juana", Apellido = "Manzo",Direccion = "Casey 4556", Email = "juanamanzo@yopmail.com", Telefono = "3333333", Borrado = true},

            //}.Where(x=> x.Borrado==true);


        }

        public IEnumerable<Persona> GetPersonasDePrueba()
        {
            using (IDbConnection db = new SqlConnection(conectionString))
            {
                List<Persona> personas = db.Query<Persona>("select * from Personas Where Borrado=0").ToList();

                return personas;
            }

            //return PersonasDePrueba;
        }

        public Persona? GetPersonaDePruebaSegunId(int IdPersona)
        {


            try
            {
                using (IDbConnection db = new SqlConnection(conectionString))
                {
                    Persona? personas = db.Query<Persona>("SELECT * FROM Personas WHERE IdPersona= " + IdPersona).FirstOrDefault();
                    return personas;
                }
            }
            catch (Exception ex)
            {
                return null;
            }



        }

        public bool AgregarPersona(Persona persona)
        {
            try
            {
                using(IDbConnection db = new SqlConnection(conectionString))
                {
                    string query = "Insert into Personas (Nombre, Apellido, Direccion, Telefono, Email) values(@Nombre,@Apellido,@Direccion, @Telefono, @Email)";
                    db.Execute(query, persona);
                    return true;
                }
                                             

            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool ModificarPersona(int IdPersona, Persona persona)
        {


            try
            {
                using( IDbConnection db = new SqlConnection(conectionString))
                {
                    string query = "UPDATE Personas SET Nombre=@Nombre, Apellido=@Apellido, Direccion=@Direccion, Telefono=@Telefono, Email=@Email WHERE IdPersona= " + IdPersona;
                    db.Execute(query, persona);
                    return true;
                }


            }
            catch (Exception ex)
            {

                return false;
            }
        }
        //Guarda que anduve toqueteando
        public bool EliminarPersona(int IdPersona)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(conectionString))
                {
                    string query="UPDATE Personas SET Borrado=1 WHERE IdPersona= "+IdPersona;
                    db.Execute(query);
                    return true;

                }
                
                
                
                
                
                
                
            //    var personaEliminar = PersonasDePrueba.Where(x => x.IdPersona == IdPersona).First();

            //    var listaPersona = PersonasDePrueba.ToList();

            //    listaPersona.Remove(personaEliminar);

            //    PersonasDePrueba.ToList().Remove(personaEliminar);



                

            }
            catch (Exception ex)
            {

                return false;
            }
        }




    }
    }

