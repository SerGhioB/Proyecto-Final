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
    class EmailClienteModelView : INotifyPropertyChanged
    {
        private ObservableCollection<EmailCliente> _EmailCliente;   /*Variable*/

        private ObservableCollection<EmailCliente> EmailClientes   /*Propiedad*/
        {
            get { return this._EmailCliente; }
            set { this._EmailCliente = value; }

        }

        public EmailClienteModelView()
        {
            this.Titulo = "Email Cliente";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;
    }
}
