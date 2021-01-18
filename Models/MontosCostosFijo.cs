using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class MontosCostosFijo
    {
        public int IdCostoFijo { get; set; }
        public string Mes { get; set; }
        public string Year { get; set; }
        public double Monto { get; set; }

        public virtual CostosFijo IdCostoFijoNavigation { get; set; }
    }
}
