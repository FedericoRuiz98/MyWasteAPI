using System;
using System.Collections.Generic;

#nullable disable

namespace MyWasteAPI.Models
{
    public partial class CategoriaSubCategorium
    {
        public int IdCategoria { get; set; }
        public int IdSubCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual SubCategoria IdSubCategoriaNavigation { get; set; }
    }
}
