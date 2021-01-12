using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ingresos = new HashSet<Ingreso>();

            Egresos = new HashSet<Egreso>();
        }

        public string Email { get; set; }
        public int IdPersona { get; set; }
        public string Password { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
        public virtual ICollection<Egreso> Egresos { get; set; }
    }
}
