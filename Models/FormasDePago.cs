using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class FormasDePago
    {
        public FormasDePago()
        {
            CostosFijos = new HashSet<CostosFijo>();
            Pasivos = new HashSet<Pasivo>();
        }

        public int IdFormaDePago { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CostosFijo> CostosFijos { get; set; }
        public virtual ICollection<Pasivo> Pasivos { get; set; }
    }
}
