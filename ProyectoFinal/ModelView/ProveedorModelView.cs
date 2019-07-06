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
    public class ProveedorModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Proveedor> _Proveedor;   /*Variable*/

        private ObservableCollection<Proveedor> Proveedores   /*Propiedad*/
        {
            get { return this._Proveedor; }
            set { this._Proveedor = value; }

        }

        public ProveedorModelView ()
        {
            this.Titulo = "Proveedor";
        }
        public string Titulo { get; set; }
        
    }
}
