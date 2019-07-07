using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A_Contraluz.Models
{
    public class CarritoCompra
    {
        public int CarritoCompraId { get; set; }
        public string Categoria { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
    }
}