﻿using amabisca.Models;
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
            if (tipo.Equals("1") || tipo.Equals("2"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
            
        }

        public IActionResult Proveedores()
        {
            if (tipo.Equals("1") || tipo.Equals("2"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
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

          [HttpPost]
           public ActionResult Ventas(String cod_producto, String cod_cliente, String cantidad)
            {
             db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into venta (cantidadventa, codcliente, codproducto, codusuario) values ('" + cantidad + "', " + int.Parse(cod_cliente) + ", " + int.Parse(cod_producto) + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();
                return View();
          }

        public IActionResult Factura()
        {
            return View();
        }

        public IActionResult Registro_clientes()
        {
            if (tipo.Equals("1") || tipo.Equals("2"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
        }


        [HttpPost]
        public IActionResult Registro_clientes(String nombre1, String nombre2, String nombre3, String apellido1, String apellido2, String nit, String telefono, String direccion, String dpi)
        {
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into cliente(nombre1, nombre2, nombre3, apellido1, apellido2, nit, telefono, direccion, dpi) values ('" + nombre1 + "', '" + nombre2 + "', '" + nombre3 + "', '" + apellido1 + "', '" + apellido2 + "','" + nit + "', '" + telefono + "', '" + direccion + "', " + Int32.Parse(dpi) + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();
            return View();
        }


        public IActionResult login()
        {
            return View();
        }


        public static String tipo = "";
        public static String nombre_usuario_actual = "";
        
        [HttpPost]
        public IActionResult login(String usuario, String contrasena)
        {
            String estado = "";
            nombre_usuario_actual = usuario;
            try { 
                String contra = "";
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

                ViewData["tipo1"] = tipo + "usuario";

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
                    estado = "1";
                    ViewData["estado"] = estado;
                    return View();
                }
            }
            catch
            {
                return View("login");
            }
        }

        public IActionResult crear_usuario()
        {
            if (tipo.Equals("1"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
            
        }

        public IActionResult Productos()
        {
            if (tipo.Equals("1") || tipo.Equals("2"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
        }
        [HttpPost]
        public IActionResult Productos(String nombre_producto, String estado, String marca, String precio, String medida, String cantidad, String proveedor, String tipovehiculo, String unidadmedida)
        {
            String cod_proveedor = "";

            int tipo = 0;

           
                if (tipovehiculo.Equals("Ligero"))
                {
                    tipo = 1;
                }
                else if (tipovehiculo.Equals("Pesado"))
                {
                    tipo = 2;
                }
                else if (tipovehiculo.Equals("Agricola"))
                {
                    tipo = 3;
                }
                else if (tipovehiculo.Equals("Motocicleta"))
                {
                    tipo = 4;
                }

                int unidad = 0;

                if (unidadmedida.Equals("Metro"))
                {
                        unidad = 1;
                }
                else if (unidadmedida.Equals("Centimetro"))
                {
                        unidad = 2;
                }
                
                if (unidadmedida.Equals("Milimetro"))
                {
                    unidad = 3;
                }
                else if (unidadmedida.Equals("Litro"))
                {
                    unidad = 4;
                }
                else if (unidadmedida.Equals("Diametro"))
                {
                    unidad = 5;
                }
                else if (unidadmedida.Equals("Altura"))
                {
                    unidad = 6;
                }
                else if (unidadmedida.Equals("Ancho"))
                {
                    unidad = 7;
                }
                else if (unidadmedida.Equals("Espesor"))
                {
                    unidad = 8;
                }
                else if (unidadmedida.Equals("Peso"))
                {
                    unidad = 9;
                }
                else if (unidadmedida.Equals("Rosca"))
                {
                    unidad = 10;
                }
        
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons1 = new SqlCommand("Select cod_proveedor from proveedor where nombre= '" + proveedor + "'", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar1 = cons1.ExecuteReader();
            while (ingresar1.Read())
            {
                cod_proveedor = ingresar1["cod_proveedor"].ToString();
            }
            db_a7311d_dbamabiscaContext.cerrar();
            //agregar,editar,eliminar
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into producto(nombre, estado, marca, precio, medida, cantidad, cod_proveedor, cod_tipo_vehiculo, cod_unidad_medida) values ('" + nombre_producto + "', '" + estado + "', '" + marca + "', " + float.Parse(precio)+ ", '" + medida + "', " + int.Parse(cantidad) + ", "+ cod_proveedor +", " + tipo + ", " + unidad + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();
            return View();

        }

        public IActionResult Inventario()
        {
            if (tipo.Equals("1") || tipo.Equals("1"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
        }

        [HttpPost]
        public IActionResult Inventario( String tipoinventario)
        {
                db_a7311d_dbamabiscaContext.abrir();
                Models.Producto.invent.Clear();
                SqlCommand cons1 = new SqlCommand("SELECT cod_producto, nombre, estado, marca, precio, cantidad from producto", db_a7311d_dbamabiscaContext.con);
                SqlDataReader ingresar2 = cons1.ExecuteReader();
                while (ingresar2.Read())
                {
                    Models.Producto.invent.Add(new Models.Producto((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (float)ingresar2[4], (int)ingresar2[5]));
                }
                return View(Models.Producto.invent);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult crear_usuario(String nombre1, String nombre2, String nombre3, String apellido1, String apellido2, String dpi, String usuario, String contrasena, String tipousuario)
        {
            int tipo1 = 0;
            if (tipo.Equals("1"))
            {  
                if (tipousuario.Equals("Administrador"))
                {
                    tipo1 = 1;
                }
                else if (tipousuario.Equals("Coordinador"))
                {
                    tipo1 = 2;
                }
                else if (tipousuario.Equals("Usuario basico"))
                {
                    tipo1 = 3;
                }
                //agregar,editar,eliminar
                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons = new SqlCommand("Insert Into usuario(Nombre1, Nombre2, Nombre3, Apellido1, Apellido2, dpi, usuario, Contraseña, cod_rol_usuario) values ('" + nombre1 + "', '" + nombre2 + "', '" + nombre3 + "', '" + apellido1 + "', '" + apellido2 + "', " + int.Parse(dpi) + ", '" + usuario + "', '" + contrasena + "', " + tipo1 + ")", db_a7311d_dbamabiscaContext.con);
                cons.ExecuteNonQuery();
                db_a7311d_dbamabiscaContext.cerrar();
                return View("popup");
            }
            else
            {
                return View("error");
            }
            
           
        }  
        
        public ActionResult cambiarcontra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cambiarcontra(String usuario, String contraa, String contran)
        {
            String contra = "";
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons1 = new SqlCommand("Select contraseña from usuario where usuario= '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar1 = cons1.ExecuteReader();
            while (ingresar1.Read())
            {
                contra = ingresar1["cod_proveedor"].ToString();
            }

            if (contra == contraa)
            {
                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons = new SqlCommand("Insert Into usuario(UPDATE usuario SET contraseña =" + contraa + "WHERE usuario = '" + usuario + "';)", db_a7311d_dbamabiscaContext.con);
                cons.ExecuteNonQuery();
                db_a7311d_dbamabiscaContext.cerrar();
                return View("popup");
            }
            else
            {
                return View("fallo");
            }

        }

        public ActionResult popup()
        {
            return View();
        }

        public ActionResult eliminar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult eliminar(String usuario, String contraa)
        {
            String contra = "";
            if (tipo.Equals("1"))
            {
                
                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons1 = new SqlCommand("Select contraseña from usuario where usuario= '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
                SqlDataReader ingresar1 = cons1.ExecuteReader();
                while (ingresar1.Read())
                {
                    contra = ingresar1["cod_proveedor"].ToString();
                }

                db_a7311d_dbamabiscaContext.cerrar();
            }
            

            if (contra == contraa)
            {
                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons = new SqlCommand("DELETE from usuario where usuario = '" + usuario + "')", db_a7311d_dbamabiscaContext.con);
                cons.ExecuteNonQuery();
                db_a7311d_dbamabiscaContext.cerrar();
                return View("popup");
            }
            else
            {
                return View("fallo");
            }
            
        }
    }
}
