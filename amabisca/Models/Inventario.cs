using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace amabisca.Models
{
    public partial class Inventario
    {
        public int CodInventario { get; set; }
        public string Descripcion { get; set; }
        public int CodProducto { get; set; }

        public virtual Producto CodProductoNavigation { get; set; }
        
       
    }

    
    
       
}
