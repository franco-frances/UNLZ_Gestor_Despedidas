using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonaController : Controller
	{

		[HttpGet]
		public IActionResult Get()
		{
			PersonaService personaService = new PersonaService();

			return Ok(personaService.GetPersonasDePrueba());
		}

		[HttpGet("{idPersona:int}")]
		public IActionResult GetPersonaPorId(int idPersona)
		{
			PersonaService personaService = new PersonaService();



			Persona? persona = personaService.GetPersonaDePruebaSegunId(idPersona);

			if (persona == null)
				return NotFound();
			else
				return Ok(persona);
		}

		[HttpPost("nuevo")]
		public IActionResult PostNuevoPersona([FromBody] Persona personaNueva)
		{
			PersonaService personaService = new PersonaService();
			personaService.AgregarPersona(personaNueva);

			return Ok();
		}

		[HttpPut("{idPersona:int}")]
		public IActionResult PutPersona(int idPersona, [FromBody] Persona persona)
		{
			PersonaService personaService = new PersonaService();
			bool resultado = personaService.ModificarPersona(idPersona, persona);


			return Ok();

		}
		//Guarda que anduve toqueteando
		[HttpDelete("{idPersona:int}")]
		public IActionResult DeletePersona(int idPersona)
		{
			PersonaService personaService = new PersonaService();
			bool resultado = personaService.EliminarPersona(idPersona);


			return Ok(personaService.GetPersonasDePrueba());
		}

	}
}
