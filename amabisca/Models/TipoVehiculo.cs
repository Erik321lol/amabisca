using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Productos = new HashSet<Producto>();
        }

        public int CodTipoVehiculo { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
