using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Model
{
    public class TipoEmpaque
    {
        public int CodigoEmpaque { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}
