using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class EventosService
    {
        public IEnumerable<Eventos> Eventos { get; set; }

        public EventosService() {

            Eventos = new List<Eventos>
            {
                new Eventos{IdEvento=1, NombreEvento="Desdepedida de José", CantidadPersonas=20, IdPersonaAgasajada=1, IdPersonaContacto= 1, IdTipoDespedida=1},
                new Eventos{IdEvento=2, NombreEvento="Desdepedida de Lorena", CantidadPersonas=30, IdPersonaAgasajada=2, IdPersonaContacto= 2, IdTipoDespedida=2}

            };

        }

        public IEnumerable<Eventos> GetEventos()
        {
            return Eventos;
        }

        public Eventos GetEventoPorId(int IdEvento)
        {
            var Evento = Eventos.Where(x => x.IdEvento == IdEvento);

            if (Evento == null)
                return null;

            return Evento.First();
        }

        public bool AgregarEventos(Eventos evento)
        {
            try
            {
            List<Eventos> lista = this.Eventos.ToList();
            lista.Add(evento);
                        
            return true;

            }
            catch (Exception ex)
            {

                return false;
            }
            
        }


    }
}
