using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioWeb.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Detallecompras = new HashSet<Detallecompra>();
        }

        public int Id { get; set; }
        public string Tipodocumento { get; set; }
        public string Numerodocumento { get; set; }
        public int? Idproveedor { get; set; }
        public DateTime? Fechacompra { get; set; }

        public virtual Proveedore IdproveedorNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompras { get; set; }
    }
}
