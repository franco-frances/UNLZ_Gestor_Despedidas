using Microsoft.AspNetCore.Mvc;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GestorEventos.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : Controller
    {
        [HttpGet]
        public IActionResult getEvento()
        {
            EventosService eventosService = new EventosService();

            return Ok(eventosService.GetEventos());
        }

        [HttpGet("{idServicio:int}")]
        public IActionResult GetEventoPorId(int idEvento)
        {
            EventosService eventosService = new EventosService();

            var evento = eventosService.GetEventoPorId(idEvento);

            if (evento == null)
                return NotFound();
            else
                return Ok(evento);
        }

        [HttpPost("nuevo")]
        public IActionResult PostNuevoServicio([FromBody] Eventos eventoNuevo)
        {

            EventosService eventoService= new EventosService();
            eventoService.AgregarEventos(eventoNuevo);

            return Ok();
        }
    }
}
