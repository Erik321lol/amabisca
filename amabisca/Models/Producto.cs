using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Inventarios = new HashSet<Inventario>();
            Venta = new HashSet<Ventum>();
        }

        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
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
