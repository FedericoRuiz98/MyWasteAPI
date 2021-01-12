using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class CostosFijo
    {
        public int IdCostoFijo { get; set; }
        public int IdEgreso { get; set; }
        public int IdFormaDePago { get; set; }
        public string Concepto { get; set; }

        public virtual Egreso IdEgresoNavigation { get; set; }
        public virtual FormasDePago IdFormaDePagoNavigation { get; set; }
    }
}
