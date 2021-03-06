using amabisca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;


namespace amabisca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult login()
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

        public IActionResult facturarpedido()
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
        public IActionResult pagos()
        {
            /*ViewData["Cabecera"] = "total";
            ViewData["total"] = */
            
            return View();

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

        public IActionResult graficastock()
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
        public ActionResult Proveedores(String nombre, String telefono, String direccion, String ciudad, String pais)
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
            if (tipo.Equals("3") || tipo.Equals("2") || tipo.Equals("1"))
            {
                return View();
            }
            else
            {
                return View("Error");
            }

        }

        public static String coddcliente = "";
        public static String coddusuario = "";
        public static double tot = 0;
        [HttpPost]
        public ActionResult Ventas(String cod_producto, String cod_cliente, String cantidad, String codusuario)
        {
            coddcliente = cod_cliente;
            coddusuario = codusuario;
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into venta (cantidad_venta, cod_cliente, cod_producto, cod_usuario, cod_transaccion) values ('" + cantidad + "', " + int.Parse(cod_cliente) + ", " + int.Parse(cod_producto) + ", " + int.Parse(codusuario) + "," + 1 + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();

            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons1 = new SqlCommand("SELECT precio from producto where cod_producto = " + int.Parse(cod_producto), db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                tot += (double)ingresar2["precio"];
            }
            tot = tot * int.Parse(cantidad);
            db_a7311d_dbamabiscaContext.cerrar();

            ViewBag.tota = tot;

            return View();
        }


       
        [HttpGet]
        public IActionResult Factura()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Ventum.ventas.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_venta, cantidad_venta, cod_cliente, cod_producto, cod_usuario from venta where cod_cliente = '" + coddcliente+ "' and cod_usuario = '" + coddusuario + "'", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Ventum.ventas.Add(new Models.Ventum((int)ingresar2[0], (String)ingresar2[1], (int)ingresar2[2], (int)ingresar2[3], (int)ingresar2[4]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            
            return new ViewAsPdf(Models.Ventum.ventas)
            {

            };
        }

        [HttpGet]
        public IActionResult Stock()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Producto.invent.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_producto, nombre, estado, marca, cantidad from producto", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Producto.invent.Add(new Models.Producto((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (int)ingresar2[4]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return View(Models.Producto.invent);

        }

        [HttpGet]
        public IActionResult Defectuosos()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Producto.invent.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT  cod_producto, nombre, estado, marca, cantidad FROM producto where estado = 'defectuoso';", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar5 = cons1.ExecuteReader();

            while (ingresar5.Read())
            {
                Models.Producto.invent.Add(new Models.Producto((int)ingresar5[0], (string)ingresar5[1], (string)ingresar5[2], (string)ingresar5[3], (int)ingresar5[4]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return View(Models.Producto.invent);

        }

        //[HttpGet]
        //public IActionResult Vendida()
        //{
        //    db_a7311d_dbamabiscaContext.abrir();
        //    Models.Producto.invent.Clear();
        //    SqlCommand cons1 = new SqlCommand("SELECT p. cod_producto, p.nombre, p.estado, p.marca, p.cantidad, v.cantidad_venta FROM producto p INNER JOIN venta v ON p.cod_producto=v.cod_producto", db_a7311d_dbamabiscaContext.con);
        //    SqlDataReader ingresar5 = cons1.ExecuteReader();

        //    while (ingresar5.Read())
        //    {
        //        Models.Producto.invent.Add(new Models.Producto((int)ingresar5[0], (string)ingresar5[1], (string)ingresar5[2], (string)ingresar5[3], (int)ingresar5[4], (string)ingresar5[5]));
        //    }
        //    db_a7311d_dbamabiscaContext.cerrar();
        //    return View(Models.Producto.invent);

        //}

        [HttpGet]
        public IActionResult facturaimpr()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.pedido.invent.Clear();
            SqlCommand cons1 = new SqlCommand("Select cod_pedido, direccion, telefono, nit, monto, cod_producto from pedido where cod_pedido = (SELECT max(cod_pedido) FROM pedido);", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.pedido.invent.Add(new Models.pedido((int)ingresar2[0], (String)ingresar2[1], (String)ingresar2[2], (String)ingresar2[3], (int)ingresar2[4], (int)ingresar2[5]));
            }
            db_a7311d_dbamabiscaContext.cerrar();

            return new ViewAsPdf(Models.pedido.invent)
            {

            };
        }


        [HttpGet]
        public IActionResult Pdf()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Producto.invent.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_producto, nombre, estado, marca, cantidad from producto", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Producto.invent.Add(new Models.Producto((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (int)ingresar2[4]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return new ViewAsPdf(Models.Producto.invent);
            {

            };
        }

        [HttpGet]
        public IActionResult Pdf2()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Producto.invent.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT  cod_producto, nombre, estado, marca, cantidad FROM producto where estado = 'defectuoso';", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Producto.invent.Add(new Models.Producto((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (int)ingresar2[4]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return new ViewAsPdf(Models.Producto.invent);
            {

            };
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
            return View("popup");
        }


        public IActionResult Index()
        {
            return View();
        }


        public static String tipo = "1";
        public static String nombre_usuario_actual = "";
        
        [HttpPost]
        public IActionResult Index(String usuario, String contrasena)
        {
            String estado = "";
            nombre_usuario_actual = usuario;
            try {
                String contra = "";
                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons = new SqlCommand("Select contrasena from usuario where usuario = '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
                SqlDataReader ingresar = cons.ExecuteReader();
                while (ingresar.Read())
                {
                    contra = ingresar["contrasena"].ToString();
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
                        return View("login");
                    }
                    else if (tipo.Equals("2"))
                    {
                        return View("login");
                    }
                    else if (tipo.Equals("3"))
                    {
                        return View("login");
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                else
                {
                    estado = "1";
                    ViewData["estado"] = estado;
                    return View("Index");
                }
            }
            catch
            {
                return View("Index");
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
                unidad = 6;
            }
            else if (unidadmedida.Equals("Altura"))
            {
                unidad = 7;
            }
            else if (unidadmedida.Equals("Ancho"))
            {
                unidad = 8;
            }
            else if (unidadmedida.Equals("Espesor"))
            {
                unidad = 9;
            }
            else if (unidadmedida.Equals("Peso"))
            {
                unidad = 10;
            }
            else if (unidadmedida.Equals("Rosca"))
            {
                unidad = 11;
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
            SqlCommand cons = new SqlCommand("Insert Into producto(nombre, estado, marca, precio, medida, cantidad, cod_proveedor, cod_tipo_vehiculo, cod_unidad_medida) values ('" + nombre_producto + "', '" + estado + "', '" + marca + "', " + float.Parse(precio) + ", '" + medida + "', " + int.Parse(cantidad) + ", " + cod_proveedor + ", " + tipo + ", " + unidad + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();
            return View();

        }



        [HttpGet]
        public IActionResult Inventario(String tipoinventario)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult crear_usuario(String nombre1, String nombre2, String nombre3, String apellido1, String apellido2, String dpi, String usuario, String contrasena, String tipousuario)
        {
            String userex = "";
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons1 = new SqlCommand("Select usuario from usuario where usuario= '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar1 = cons1.ExecuteReader();

            while (ingresar1.Read())
            {
                userex = ingresar1["usuario"].ToString();
            }
            db_a7311d_dbamabiscaContext.cerrar();
            if (usuario.Equals(userex))
            {
                return View("error");
            }
            else
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
                    SqlCommand cons = new SqlCommand("Insert Into usuario(Nombre1, Nombre2, Nombre3, Apellido1, Apellido2, dpi, usuario, Contrasena, cod_rol_usuario) values ('" + nombre1 + "', '" + nombre2 + "', '" + nombre3 + "', '" + apellido1 + "', '" + apellido2 + "', " + int.Parse(dpi) + ", '" + usuario + "', '" + contrasena + "', " + tipo1 + ")", db_a7311d_dbamabiscaContext.con);
                    cons.ExecuteNonQuery();
                    db_a7311d_dbamabiscaContext.cerrar();
                    return View("popup");
                }
                else
                {
                    return View("error");
                }
            }
        }

        public ActionResult cambiarcontra()
        {
            if (tipo.Equals("1") || tipo.Equals("2") || tipo.Equals("3"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
        }

        [HttpPost]
        public ActionResult cambiarcontra(String usuario, String contraa, String contran)
        {
            String contra = "";
            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons1 = new SqlCommand("Select contrasena from usuario where usuario= '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar1 = cons1.ExecuteReader();

            while (ingresar1.Read())
            {
                contra = ingresar1["contrasena"].ToString();
            }
            db_a7311d_dbamabiscaContext.cerrar();
            if (contra == contraa)
            {
                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons = new SqlCommand("UPDATE usuario SET contrasena =" + contran + "WHERE usuario = '" + usuario + "';", db_a7311d_dbamabiscaContext.con);
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
            if (tipo.Equals("1"))
            {
                return View();
            }
            else
            {
                return View("error");
            }
        }

        [HttpPost]
        public ActionResult eliminar(String usuario, String contraa)
        {
            String contra = "";
            if (tipo.Equals("1"))
            {

                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons1 = new SqlCommand("Select contrasena from usuario where usuario= '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
                SqlDataReader ingresar1 = cons1.ExecuteReader();
                while (ingresar1.Read())
                {
                    contra = ingresar1["contrasena"].ToString();
                }

                db_a7311d_dbamabiscaContext.cerrar();
            }


            if (contra == contraa)
            {
                db_a7311d_dbamabiscaContext.abrir();
                SqlCommand cons = new SqlCommand("DELETE from usuario where usuario = '" + usuario + "'", db_a7311d_dbamabiscaContext.con);
                cons.ExecuteNonQuery();
                db_a7311d_dbamabiscaContext.cerrar();
                return View("popup");
            }
            else
            {
                return View("fallo");
            }

        }

        public ActionResult altas_bajas()
        {
            if (tipo.Equals("2") || tipo.Equals("1"))
            {
                return View();
            }
            else
            {
                return View("error");
            }

        }

        [HttpPost]
        public ActionResult altas_bajas(String altabaja, String codigo_producto)
        {
            String tipo = " ";

            if (altabaja.Equals("Alta"))
            {
                tipo = "Alta";
            }
            else if (altabaja.Equals("Baja"))
            {
                tipo = "Baja";
            }

            db_a7311d_dbamabiscaContext.abrir();
            SqlCommand cons = new SqlCommand("Insert Into alta_baja(tipo, cod_producto) values ('" + tipo + "', " + int.Parse(codigo_producto) + ")", db_a7311d_dbamabiscaContext.con);
            cons.ExecuteNonQuery();
            db_a7311d_dbamabiscaContext.cerrar();

            return View();
        }

        public ActionResult reportes()
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

        [HttpGet]
        public ActionResult todos_productos()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Producto.invent.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_producto, nombre, estado, marca, cantidad from producto", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Producto.invent.Add(new Models.Producto((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (int)ingresar2[4]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return View(Models.Producto.invent);

        }

        [HttpGet]
        public ActionResult pdf3()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Producto.invent.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_producto, nombre, estado, marca, cantidad from producto", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Producto.invent.Add(new Models.Producto((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (int)ingresar2[4]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return new ViewAsPdf(Models.Producto.invent);

        }

        [HttpGet]
        public ActionResult todos_proveedores()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Proveedor.proveedores.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_proveedor, nombre, direccion, telefono, pais, ciudad from proveedor", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Proveedor.proveedores.Add(new Models.Proveedor((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (string)ingresar2[4], (string)ingresar2[5]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return View(Models.Proveedor.proveedores);

        }

        [HttpGet]
        public ActionResult pdf4()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Proveedor.proveedores.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_proveedor, nombre, direccion, telefono, pais, ciudad from proveedor", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Proveedor.proveedores.Add(new Models.Proveedor((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (string)ingresar2[4], (string)ingresar2[5]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return View(Models.Proveedor.proveedores);

        }

        [HttpGet]
        public ActionResult todos_clientes()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Cliente.clientes.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_cliente, nombre1, nombre2, apellido1, apellido2, nit, telefono, direccion from cliente", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Cliente.clientes.Add(new Models.Cliente((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (string)ingresar2[4], (string)ingresar2[5], (string)ingresar2[6], (string)ingresar2[7]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return View(Models.Cliente.clientes);

        }

        [HttpGet]
        public ActionResult pdf5()
        {
            db_a7311d_dbamabiscaContext.abrir();
            Models.Cliente.clientes.Clear();
            SqlCommand cons1 = new SqlCommand("SELECT cod_cliente, nombre1, nombre2, apellido1, apellido2, nit, telefono, direccion from cliente", db_a7311d_dbamabiscaContext.con);
            SqlDataReader ingresar2 = cons1.ExecuteReader();

            while (ingresar2.Read())
            {
                Models.Cliente.clientes.Add(new Models.Cliente((int)ingresar2[0], (string)ingresar2[1], (string)ingresar2[2], (string)ingresar2[3], (string)ingresar2[4], (string)ingresar2[5], (string)ingresar2[6], (string)ingresar2[7]));
            }
            db_a7311d_dbamabiscaContext.cerrar();
            return View(Models.Cliente.clientes);

        }

        public ActionResult opciones_usuario()
        {
            if (tipo.Equals("3") || tipo.Equals("2") || tipo.Equals("1"))
            {
                return View();
            }
            else
            {
                return View("Error");
            }
        }

        
    }
}
