using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Cliente
    {

        public static List<Cliente> clientes = new List<Cliente>();

        public Cliente(object v) { }

        public Cliente(int cod_cliente, String nombre1, String nombre2, String apellido1, String apellido2, String nit, String telefono, String direccion)
        {
            Venta = new HashSet<Ventum>();
            CodCliente = cod_cliente;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Nit = nit;
            Telefono = telefono;
            Direccion = direccion;
        }

        public int CodCliente { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Nombre3 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public long Dpi { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
