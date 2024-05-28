using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : Controller
    {
                
            [HttpGet]
            public IActionResult Get()
            {
                LocalidadService localidadService= new LocalidadService();

                return Ok(localidadService.GetLocalidades());
            }

            [HttpGet("{Id_Externo:int}")]
            public IActionResult GetLocalidadPorId(int Id_Externo)
            {
                LocalidadService localidadService = new LocalidadService();



                Localidad localidad = localidadService.GetLocalidadSegunId(Id_Externo);

                if (localidad == null)
                    return NotFound();
                else
                    return Ok(localidad);
            }

    }
}

