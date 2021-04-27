using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class UnidadMedidum
    {
        public UnidadMedidum()
        {
            Productos = new HashSet<Producto>();
        }

        public int CodUnidadMedida { get; set; }
        public string NombreUnidadMedida { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
