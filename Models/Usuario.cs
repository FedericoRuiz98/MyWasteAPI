using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Egresos = new HashSet<Egreso>();
            Ingresos = new HashSet<Ingreso>();
        }

        public string Email { get; set; }
        public int IdPersona { get; set; }
        public string Password { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Egreso> Egresos { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
