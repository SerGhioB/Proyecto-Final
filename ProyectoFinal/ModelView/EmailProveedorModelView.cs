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
    class EmailProveedorModelView :INotifyPropertyChanged
    {
        private ObservableCollection<EmailProveedor> _EmailProveedor;   /*Variable*/

        private ObservableCollection<EmailProveedor> EmailProveedores   /*Propiedad*/
        {
            get { return this._EmailProveedor; }
            set { this._EmailProveedor = value; }

        }

        public EmailProveedorModelView()
        {
            this.Titulo = "Email Proveedor";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;        
    }
}
