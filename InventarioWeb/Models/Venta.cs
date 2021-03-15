using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Detalleventa = new HashSet<Detalleventum>();
        }

        public int Id { get; set; }
        public string Tipodocumento { get; set; }
        public string Numerodocumento { get; set; }
        public int? Idcliente { get; set; }
        public DateTime? Fechaventa { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual ICollection<Detalleventum> Detalleventa { get; set; }
    }
}
