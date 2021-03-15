using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Detallecompra
    {
        public int Idcompra { get; set; }
        public int Idproducto { get; set; }
        public int? Cantidad { get; set; }

        public virtual Compra IdcompraNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
    }
}
