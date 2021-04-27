using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CodVenta { get; set; }
        public string CantidadVenta { get; set; }
        public int CodCliente { get; set; }
        public int CodProducto { get; set; }
        public int CodUsuario { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; }
        public virtual Producto CodProductoNavigation { get; set; }
        public virtual Usuario CodUsuarioNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
