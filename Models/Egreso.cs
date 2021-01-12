using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Egreso
    {
        public Egreso()
        {
            CostosFijos = new HashSet<CostosFijo>();
            Pasivos = new HashSet<Pasivo>();
        }

        public int IdEgreso { get; set; }
        public string Mes { get; set; }
        public double Total { get; set; }
        public  string email { get; set; }

        public virtual ICollection<CostosFijo> CostosFijos { get; set; }
        public virtual ICollection<Pasivo> Pasivos { get; set; }
    }
}
