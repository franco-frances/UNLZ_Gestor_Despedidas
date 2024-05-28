using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class LocalidadService
    {

        public IEnumerable<Localidad> localidades { get; set; }

        public LocalidadService()
        {
            localidades = new List<Localidad>
            {
                new Localidad{ Id_Externo=1, Descripcion="Coronel Suarez" },
                new Localidad{ Id_Externo=2, Descripcion="Bahia Blanca" },
                new Localidad{ Id_Externo=3, Descripcion="Buenos Aires" },

            };
        }

        public IEnumerable<Localidad> GetLocalidades()
        {
            return localidades;
        }

        public Localidad GetLocalidadSegunId(int IdLocalidad)
        {


            try
            {
                Localidad localidad = localidades.Where(x => x.Id_Externo == IdLocalidad).First();
                return localidad;
            }
            catch (Exception ex)
            {
                return null;
            }



        }

    }
}
