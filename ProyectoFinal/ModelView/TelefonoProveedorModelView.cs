using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProyectoFinal.ModelView
{
    class TelefonoProveedorModelView : INotifyPropertyChanged
    {
        public TelefonoProveedorModelView()
        {
            this.Titulo = "Telefono Proveedor";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;
    }
}
