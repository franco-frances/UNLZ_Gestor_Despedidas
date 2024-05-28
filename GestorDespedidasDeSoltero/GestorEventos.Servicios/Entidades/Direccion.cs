using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Direccion
    {
        //DireccionCalle, DireccionNumero, DireccionPiso, DireccionDepartamento,
        //DireccionIdLocalidad (IdExterno), DireccionIdProvincia (IdExterno), DireccionCodigoPostal. 


        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string CodigoPostal { get; set; }
        public Localidad Localidad { get; set; }
        public Provincia Provincia { get; set; }

        


        

    }

}

