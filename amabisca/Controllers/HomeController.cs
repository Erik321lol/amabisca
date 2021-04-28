using amabisca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace amabisca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //agregar,editar,eliminar
            //db_a7311d_dbamabiscaContext.abrir();
            //SqlCommand cons = new SqlCommand("Insert Into Cliente(Nombre1, Nombre2, Apellido1, Apellido2, Nit, Telefono, Direccion, Dpi) values ('Erik', 'Adolfo', 'Mendez', 'Guillen', '12345678', '12345678', 'ciudad',201845335)", db_a7311d_dbamabiscaContext.con);
            //cons.ExecuteNonQuery();
            //db_a7311d_dbamabiscaContext.cerrar();
            
            //consultar
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Select * from Cliente", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar = cons.ExecuteReader();
            while (ingresar.Read())
            { 
                ViewData["nombre"] = ingresar["Nombre1"].ToString();
            } 
            db_a7311d_dbamabiscaContext.cerrar();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Proveedores()
        {
            return View();
        }

        public IActionResult Ventas()
        {
            return View();
        }

        public IActionResult Registro_clientes()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult crear_usuario()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult Inventario()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpPost]
        public ActionResult crear_usuario(String nombre)
        {
            ViewBag.Marca = nombre;
            return View();
        }
    }
}
