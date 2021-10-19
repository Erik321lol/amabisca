using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Ventum
    {
        public static List<Ventum> ventas = new List<Ventum>();
        public Ventum(int cod_venta, string cantidad, int cod_cliente, int cod_producto, int cod_usuario)
        {
            Facturas = new HashSet<Factura>();
            CodVenta = cod_venta;
            CantidadVenta = cantidad;
            CodCliente = cod_cliente;
            CodProducto = cod_producto;
            CodUsuario = cod_usuario;
        }

        public int CodVenta { get; set; }
        public string CantidadVenta { get; set; }
        public int CodCliente { get; set; }
        public int CodProducto { get; set; }
        public int CodUsuario { get; set; }
        public int Cod_transaccion { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; }
        public virtual Producto CodProductoNavigation { get; set; }
        public virtual Usuario CodUsuarioNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
