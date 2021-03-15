using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioWeb.Helpers
{
    public class Paginacion
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
    }
}
