using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProyectoFinal.ModelView
{
    class DetalleFacturaModelView : INotifyPropertyChanged
    {
        public DetalleFacturaModelView()
        {
            this.Titulo = "Detalle Factura";
        }
        public string Titulo {get; set;}
        public event ProgressChangedEventHandler PropertyChanged;        
    }
}
