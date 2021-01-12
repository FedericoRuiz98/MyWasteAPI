using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class TiposIngreso
    {
        public TiposIngreso()
        {
            Ingresos = new HashSet<Ingreso>();
        }

        public int IdTipoIngreso { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
