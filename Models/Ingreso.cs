using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Ingreso
    {
        public int IdIngreso { get; set; }
        public int IdTipoIngreso { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public virtual Usuario EmailNavigation { get; set; }
        public virtual TiposIngreso IdTipoIngresoNavigation { get; set; }
    }
}
