using System;
using System.Collections.Generic;

#nullable disable

namespace amabisca.Models
{
    public partial class RolUsuario
    {
        public RolUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int CodRolUsuario { get; set; }
        public string NombreRol { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
