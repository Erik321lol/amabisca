using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
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
