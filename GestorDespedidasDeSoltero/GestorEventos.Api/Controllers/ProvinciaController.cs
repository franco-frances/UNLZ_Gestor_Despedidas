using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            ProvinciaService provinciaService = new ProvinciaService();

            return Ok(provinciaService.GetProvincias());
        }

        [HttpGet("{Id_Externo:int}")]
        public IActionResult GetProvinciaPorId(int Id_Externo)
        {
            ProvinciaService provinciaService = new ProvinciaService();




            Provincia provincia = provinciaService.GetProvinciasSegunId(Id_Externo);

            if (provincia == null)
                return NotFound();
            else
                return Ok(provincia);
        }
    }
}
