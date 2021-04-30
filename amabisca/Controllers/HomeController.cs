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
            /*db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Select * from Cliente", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar = cons.ExecuteReader();
            while (ingresar.Read())
            { 
                ViewData["nombre"] = ingresar["Nombre1"].ToString();
            } 
            db_a7311d_dbamabiscaContext.cerrar();*/

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

        [HttpPost]
        public ActionResult Proveedores( String nombre, String telefono, String direccion, String ciudad, String pais)
        {
            //agregar,editar,eliminar
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into proveedor(nombre, direccion, telefono, pais, ciudad) values ('" + nombre + "', '" + direccion + "', '" + telefono + "', '" + pais + "', '" + ciudad + "')", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();
            return View();
        }

        public IActionResult Ventas()
        {
            return View();
        }

        /*   [HttpPost]
           public ActionResult Ventas(String cod_producto, String nombre, String cantidad)
            {
         agregar,editar,eliminar
             db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into proveedor values ('" + int.Parse(cod_producto) + "', '" + nombre + "', '" + int.Parse(cantidad) + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();
                return View();
          }*/

        public IActionResult Factura()
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

        [HttpPost]
        public IActionResult login(String usuario, String contrasena)
        {
            String contra = "";
            String tipo = "";
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Select contraseña from usuario where usuario = '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar = cons.ExecuteReader(); 
            while (ingresar.Read())
            {
                contra = ingresar["contraseña"].ToString();
            }
            db_a7311d_dbamabiscaContext.cerrar();

            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons1 = new SqlCommand("Select cod_rol_usuario from usuario where usuario = '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar1 = cons1.ExecuteReader();
            while (ingresar1.Read())
            {
                tipo = ingresar1["cod_rol_usuario"].ToString();
            }
            db_a7311d_dbamabiscaContext.cerrar();


            if (contra.Equals(contrasena))
            {
                if (tipo.Equals("1"))
                {
                    return View("Index");
                }
                else if (tipo.Equals("2"))
                {
                    return View("Index");
                }
                else if (tipo.Equals("3"))
                {
                    return View("Index");
                }
                return View("Index");

            }
            else
            {
                return View("login");
            }
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
        public ActionResult crear_usuario(String nombre1, String nombre2, String nombre3, String apellido1, String apellido2, String dpi, String usuario, String contrasena, String tipousuario)
        {
            int tipo = 0;
            if (tipousuario.Equals("Administrador"))
            {
                tipo = 1;
            }else if (tipousuario.Equals("Coordinador"))
            {
                tipo = 2;
            }
            else if (tipousuario.Equals("Usuario basico"))
            {
                tipo = 3;
            }
            //agregar,editar,eliminar
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into usuario(Nombre1, Nombre2, Nombre3, Apellido1, Apellido2, dpi, usuario, Contraseña, cod_rol_usuario) values ('" + nombre1 + "', '" + nombre2 + "', '" + nombre3 + "', '" + apellido1 + "', '" + apellido2 + "', " + int.Parse(dpi) + ", '" + usuario + "', '" + contrasena + "', " + tipo + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();
            return View();
        }       
    }
}
