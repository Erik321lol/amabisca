using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amabisca.Models
{

    public class pedido
    {

        public static List<pedido> invent = new List<pedido>();
        public pedido(object v) { }
        public pedido(int cod_pedido1, String direccion1, String telefono1, String nit1, int monto1, int cod_producto1)
        {
            Inventarios = new HashSet<Inventario>();
            Venta = new HashSet<Ventum>();
            cod_pedido = cod_pedido1;
            direccion = direccion1;
            telefono = telefono1;
            nit = nit1;
            monto = monto1;
            cod_producto = cod_producto1;
        }

        public int cod_pedido { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string nit { get; set; }
        public int monto { get; set; }
        public int estado { get; set; }
        public String producto { get; set; }
        public int cod_producto { get; set; }
        public virtual Proveedor CodProveedorNavigation { get; set; }
        public virtual TipoVehiculo CodTipoVehiculoNavigation { get; set; }
        public virtual UnidadMedidum CodUnidadMedidaNavigation { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }


    }
}
