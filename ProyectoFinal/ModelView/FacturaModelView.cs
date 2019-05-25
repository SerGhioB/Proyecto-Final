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
    class FacturaModelView : INotifyPropertyChanged
    {
        private ObservableCollection<Factura> _Factura;   /*Variable*/

        private ObservableCollection<Factura> Facturas   /*Propiedad*/
        {
            get { return this._Factura; }
            set { this._Factura = value; }

        }

        public FacturaModelView()
        {
            this.Titulo = "Factura";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;
    }
}
