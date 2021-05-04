using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Producto
    {
        public static List<Producto> invent = new List<Producto>();
        public Producto(object v) { }
        public Producto(int cod_producto, String nombre, String estado, String marca, int cantidad)
        {
            Inventarios = new HashSet<Inventario>();
            Venta = new HashSet<Ventum>();
            CodProducto = cod_producto;
            Nombre = nombre;
            Estado = estado;
            Marca = marca;
            Cantidad = cantidad;
        }

        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Marca { get; set; }
        public float Precio { get; set; }
        public string Medida { get; set; }
        public int Cantidad { get; set; }
        public int CodProveedor { get; set; }
        public int CodTipoVehiculo { get; set; }
        public int CodUnidadMedida { get; set; }

        public virtual Proveedor CodProveedorNavigation { get; set; }
        public virtual TipoVehiculo CodTipoVehiculoNavigation { get; set; }
        public virtual UnidadMedidum CodUnidadMedidaNavigation { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
