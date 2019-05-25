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
    class ClienteModelView : INotifyPropertyChanged
    {
        private ObservableCollection<Cliente> _Cliente;   /*Variable*/
        
        private ObservableCollection<Cliente> Clientes   /*Propiedad*/
        {
            get { return this._Cliente; }
            set { this._Cliente = value; }

        }

        public ClienteModelView ()
        {
            this.Titulo = "Cliente";        
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;

    }
}
