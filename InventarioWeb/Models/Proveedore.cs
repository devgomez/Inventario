using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public string Tipodocumento { get; set; }
        public string Numerodocumento { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
