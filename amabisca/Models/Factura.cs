using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Factura
    {
        public int CodFactura { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public int CodVenta { get; set; }
        public virtual Ventum CodVentaNavigation { get; set; }
    }
}
