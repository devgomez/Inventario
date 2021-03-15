using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Especificacionesproducto
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Producto")]
        public int? Idproducto { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }

        public virtual Producto IdproductoNavigation { get; set; }
    }
}
