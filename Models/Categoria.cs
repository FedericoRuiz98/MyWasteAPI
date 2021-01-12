using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Pasivos = new HashSet<Pasivo>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descp { get; set; }

        public virtual ICollection<Pasivo> Pasivos { get; set; }
    }
}
