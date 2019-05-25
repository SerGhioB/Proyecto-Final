using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProyectoFinal.Model;
using System.Collections.ObjectModel;

namespace ProyectoFinal.ModelView
{
    class DetalleFacturaModelView : INotifyPropertyChanged
    {
        private ObservableCollection<DetalleFactura> _DetalleFactura;   /*Variable*/

        private ObservableCollection<DetalleFactura> DetalleFacturas   /*Propiedad*/
        {
            get { return this._DetalleFactura; }
            set { this._DetalleFactura = value; }

        }

        public DetalleFacturaModelView()
        {
            this.Titulo = "Detalle Factura";
        }
        public string Titulo {get; set;}
        public event ProgressChangedEventHandler PropertyChanged;        
    }
}
