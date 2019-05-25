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
    class TelefonoProveedorModelView : INotifyPropertyChanged
    {
        private ObservableCollection<TelefonoProveedor> _TelefonoProveedor;   /*Variable*/

        private ObservableCollection<TelefonoProveedor> TelefonoProvedores   /*Propiedad*/
        {
            get { return this._TelefonoProveedor; }
            set { this._TelefonoProveedor = value; }

        }

        public TelefonoProveedorModelView()
        {
            this.Titulo = "Telefono Proveedor";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;
    }
}
