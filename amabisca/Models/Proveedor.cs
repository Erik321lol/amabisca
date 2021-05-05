using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    
    public partial class Proveedor
    {

        public static List<Proveedor> proveedores = new List<Proveedor>();

        public Proveedor(object v) { }

        public Proveedor(int cod_proveedor, String nombre, String direccion, String telefono, String pais, String ciudad)
        {
            Productos = new HashSet<Producto>();
            CodProveedor = cod_proveedor;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Pais = pais;
            Ciudad = ciudad;
        }

        public int CodProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
