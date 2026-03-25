using Microsoft.AspNetCore.Mvc;
using MvcPruebaPersonasApi.Models;
using MvcPruebaPersonasApi.Services;
using System.Threading.Tasks;

namespace MvcPruebaPersonasApi.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceEmpleados service;
        public EmpleadosController(ServiceEmpleados service) 
        { 
            this.service = service; 
        }
        public async Task<IActionResult> Index()
        {
            List<Empleado> empleados = await this.service.GetEmpleadosAsync();
            return View(empleados);
        }
        public async Task<IActionResult> Details(int id)
        {
            Empleado empleado = await this.service.FindEmpleadoAsync(id);
            return View(empleado);
        }
    }
}
