using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Gasto
    {
        public int IdGasto { get; set; }
        public int IdSubCategoria { get; set; }
        public int IdPasivo { get; set; }
        public double Monto { get; set; }
        public string Concepto { get; set; }

        public virtual Pasivo IdPasivoNavigation { get; set; }
        public virtual SubCategoria IdSubCategoriaNavigation { get; set; }
    }
}
