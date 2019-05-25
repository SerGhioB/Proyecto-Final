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
    class DetalleCompraModelView :INotifyPropertyChanged
    {
        private ObservableCollection<DetalleCompra> _DetalleCompra;   /*Variable*/

        private ObservableCollection<DetalleCompra> DetalleCompras   /*Propiedad*/
        {
            get { return this._DetalleCompra; }
            set { this._DetalleCompra = value; }

        }

        public DetalleCompraModelView()
        {
            this.Titulo = "Detalle Compra";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;        
    }
}
