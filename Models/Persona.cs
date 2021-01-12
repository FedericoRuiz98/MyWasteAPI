using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPresona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
