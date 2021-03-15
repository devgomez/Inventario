using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Multiuso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public int? Idpadre { get; set; }
        public int? Orden { get; set; }
        public string Tipodato { get; set; }
        public bool? Estado { get; set; }
    }
}
