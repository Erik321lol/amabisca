using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
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
