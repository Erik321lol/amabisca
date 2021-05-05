using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amabisca.Models
{
    public class InnerJoin
    {
        public static List<Ventas> ventas = new List<Ventas>();
        public static List<Producto> producto = new List<Producto>();
    public class Ventas
        {
            public string CantidadVenta { get; set; }
            public int CodCliente { get; set; }
            public int CodProducto { get; set; }
            public int CodUsuario { get; set; }
            public Ventas() { }
            public Ventas(string cantidad)
            {
                CantidadVenta = cantidad;
            
            }

        }
        public class Producto
        {
            public int CodProducto { get; set; }
            public string Nombre { get; set; }
            public string Estado { get; set; }
            public string Marca { get; set; }
            public float Precio { get; set; }
            public string Medida { get; set; }
            public int Cantidad { get; set; }
            public Producto() { }
            public Producto( string nombre)
            {
        
                Nombre = nombre;
            }
        }
        public class Usuario
        {
            public string Nombre1 { get; set; }
            public string Nombre2 { get; set; }
            public string Nombre3 { get; set; }
            public string Apellido1 { get; set; }
            public string Apellido2 { get; set; }
            public Usuario()
            {

            }
            public Usuario(string nombre1, string nombre2, string nombre3, string apellido1, string apellido2)
            {
                Nombre1 = nombre1;
                Nombre2 = nombre2;
                Nombre3 = nombre3;
                Apellido1 = apellido1;
                Apellido2 = apellido2;
            }
        }
        public class Cliente
        {
            public string Nombre1 { get; set; }
            public string Nombre2 { get; set; }
            public string Nombre3 { get; set; }
            public string Apellido1 { get; set; }
            public string Apellido2 { get; set; }
            public string Nit { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public Cliente() { }
            public Cliente(string nombre1, string nombre2, string nombre3, string apellido1, string apellido2, string nnit, string telefono, string direccion)
            {
                Nombre1 = nombre1;
                Nombre2 = nombre2;
                Nombre3 = nombre3;
                Apellido1 = apellido1;
                Apellido2 = apellido2;
                Nit = nnit;
                Telefono = telefono;
                Direccion = direccion;
            }

        }
    }
}
