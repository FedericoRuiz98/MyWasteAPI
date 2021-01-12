using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Balance
    {
        public int IdIngreso { get; set; }
        public int IdEgreso { get; set; }
        public double Balance1 { get; set; }

        public virtual Egreso IdEgresoNavigation { get; set; }
        public virtual Ingreso IdIngresoNavigation { get; set; }
    }
}
