using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Venta = new HashSet<Ventum>();
        }

        public int CodUsuario { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Nombre3 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public long? Dpi { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
        public int CodRolUsuario { get; set; }

        public virtual RolUsuario CodRolUsuarioNavigation { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
