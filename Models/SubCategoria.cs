using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class SubCategoria
    {
        public SubCategoria()
        {
            Gastos = new HashSet<Gasto>();
        }

        public int IdSubCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descp { get; set; }

        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
