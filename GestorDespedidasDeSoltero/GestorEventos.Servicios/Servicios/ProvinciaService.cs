using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
      public class ProvinciaService
    {
        public IEnumerable<Provincia> Provincias { get; set; }

        public ProvinciaService()
        {
            Provincias = new List<Provincia>
            {
                new Provincia{ Id_Externo=1, Descripcion="Buenos Aires" },
                new Provincia{ Id_Externo=2, Descripcion="Cordoba" },
                new Provincia{ Id_Externo=3, Descripcion="Santa Fé" },

            };
        }

        public IEnumerable<Provincia> GetProvincias()
        {
            return Provincias;
        }

        public Provincia GetProvinciasSegunId(int IdProvincia)
        {


            try
            {
               Provincia provincia = Provincias.Where(x => x.Id_Externo == IdProvincia).First();
                return provincia;
            }
            catch (Exception ex)
            {
                return null;
            }



        }
    }
}
