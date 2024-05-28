using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEventos.WebAdmin.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: ServiciosController
        public ActionResult Index()
        {
            ServiciosService servicios = new ServiciosService();
            
            
            return View(servicios.GetServicios());
        }

        // GET: ServiciosController/Details/5
        public ActionResult Details(int id)
        {
            ServiciosService serviciosService = new ServiciosService();


            return View(serviciosService.GetServiciosPorId(id));
        }

        // GET: ServiciosController/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: ServiciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ServiciosService servicioService=new ServiciosService();
                ServiciosVM servicio=new ServiciosVM();

                servicio.Descripcion= collection["Descripcion"].ToString();
                servicio.PrecioServicio = decimal.Parse(collection["PrecioServicio"].ToString());

                servicioService.AgregarServicio(servicio);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiciosController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiciosService serviciosService = new ServiciosService();


            return View(serviciosService.GetServiciosPorId(id));
        }

        // POST: ServiciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ServiciosService serviciosService =new ServiciosService(); 
                ServiciosVM servicio=new ServiciosVM();

                servicio.Descripcion = collection["Descripcion"].ToString();
                servicio.PrecioServicio = decimal.Parse(collection["PrecioServicio"].ToString());

                serviciosService.modificarServicio(id,servicio);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiciosController/Delete/5
        public ActionResult Delete(int id)
        {
            ServiciosService serviciosService = new ServiciosService();


            return View(serviciosService.GetServiciosPorId(id));
        }

        // POST: ServiciosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ServiciosService serviciosService = new ServiciosService();
                serviciosService.Borrar(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
