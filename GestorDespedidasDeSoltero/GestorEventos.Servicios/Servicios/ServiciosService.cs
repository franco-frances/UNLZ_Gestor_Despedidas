
using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GestorEventos.Servicios.Servicios
{
	public class ServiciosService
	{
		//public IEnumerable<ServiciosVM> Servicios { get; set; }
        private string conectionString;

        public ServiciosService ()
		{
			
			conectionString= "Server=.\\SQLEXPRESS;Database=master;Integrated Security=True;";


            //this.Servicios = new List<ServiciosVM>
            //{
            //	new ServiciosVM{ IdServicio = 1, Descripcion = "Bar Hopping", PrecioServicio = 25000 },
            //	new ServiciosVM{ IdServicio = 2, Descripcion = "Servicio de Transporte", PrecioServicio = 20000 },
            //	new ServiciosVM{ IdServicio = 3, Descripcion = "Entradas de Boliches Incluidas", PrecioServicio = 10000 }
            //};
        }

		public IEnumerable<ServiciosVM> GetServicios()
		{
            using (IDbConnection db = new SqlConnection(conectionString))
            {
                List<ServiciosVM> servicios = db.Query<ServiciosVM>("select * from Servicios Where Borrado=0").ToList();

                return servicios;
            }
        }

		public ServiciosVM? GetServiciosPorId(int IdServicio)
		{
            try
            {
                using (IDbConnection db = new SqlConnection(conectionString))
                {
                    ServiciosVM? servicios = db.Query<ServiciosVM>("SELECT * FROM Servicios WHERE IdServicio= " + IdServicio).FirstOrDefault();
                    return servicios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


            //var servicios = Servicios.Where(x => x.IdServicio == IdServicio);

            //if (servicios == null)
            //	return null;

            //return servicios.First();
        }


		public bool AgregarServicio(ServiciosVM servicio )
		{
            		
            try
            {
                using (IDbConnection db = new SqlConnection(conectionString))
                {
                    string query = "Insert into Servicios (Descripcion, PrecioServicio, Borrado) values (@Descripcion,@PrecioServicio, @Borrado)";
                    db.Execute(query, servicio);
                    return true;
                }


            }
            catch (Exception ex)
            {

                return false;
            }
            		
            //			
            //			try
            //			{
            //				List<ServiciosVM> lista = this.Servicios.ToList();
            //				lista.Add(servicio);
            ////				this.Servicios.ToList().Add(servicio);
            //				return true;
            //			}
            //			catch(Exception ex)
            //			{
            //				return false;
            //			}


        }

        public bool modificarServicio(int IdServicio, ServiciosVM servicio)
        {

            try
            {

            using (IDbConnection db = new SqlConnection(conectionString))
            {
                string query = "UPDATE Servicios SET Descripcion=@Descripcion, PrecioServicio=@PrecioServicio WHERE IdServicio= " + IdServicio;
                db.Execute(query, servicio);
                return true;

            }
            }
            catch (Exception ex)
            {

                return false;
            }
            
            


        }

        public bool Borrar(int IdServicio)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(conectionString))
                {
                    string query = "UPDATE Servicios SET Borrado=1 WHERE IdServicio= " + IdServicio;
                    db.Execute(query);
                    return true;

                }
            }
            catch (Exception)
            {

                return false;
            }
        }


	}
}
