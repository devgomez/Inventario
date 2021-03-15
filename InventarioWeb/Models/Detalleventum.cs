using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Detalleventum
    {
        public int Idventa { get; set; }
        public int Idproducto { get; set; }
        public int? Cantidad { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
        public virtual Venta IdventaNavigation { get; set; }
    }
}
