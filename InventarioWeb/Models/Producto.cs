using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detallecompras = new HashSet<Detallecompra>();
            Detalleventa = new HashSet<Detalleventum>();
            Especificacionesproductos = new HashSet<Especificacionesproducto>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Preciocompra { get; set; }
        public decimal? Precioventa { get; set; }
        public int? Stock { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Detallecompra> Detallecompras { get; set; }
        public virtual ICollection<Detalleventum> Detalleventa { get; set; }
        public virtual ICollection<Especificacionesproducto> Especificacionesproductos { get; set; }
    }
}
