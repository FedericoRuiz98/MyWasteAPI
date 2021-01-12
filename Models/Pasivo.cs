using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Pasivo
    {
        public Pasivo()
        {
            Gastos = new HashSet<Gasto>();
        }

        public int IdPasivo { get; set; }
        public int IdCategoria { get; set; }
        public int IdFormaDePago { get; set; }
        public int IdEgreso { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public int? Cuotas { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Egreso IdEgresoNavigation { get; set; }
        public virtual FormasDePago IdFormaDePagoNavigation { get; set; }
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
