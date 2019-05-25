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
    class TelefonoClienteModelView : INotifyPropertyChanged
    {
        private ObservableCollection<TelefonoCliente> _TelefonoCliente;   /*Variable*/

        private ObservableCollection<TelefonoCliente> TelefonoClientes   /*Propiedad*/
        {
            get { return this._TelefonoCliente; }
            set { this._TelefonoCliente = value; }

        }

        public TelefonoClienteModelView()
        {
            this.Titulo = "Telefono Cliente";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;        
    }
}
