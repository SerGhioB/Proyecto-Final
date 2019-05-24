using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Model
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int NumeroDescuento { get; set; }
        public int CodigoProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public virtual Proveedor Proveedor { get; set; }

    }
}
