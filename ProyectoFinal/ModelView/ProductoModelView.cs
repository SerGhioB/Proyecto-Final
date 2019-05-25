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
    class ProductoModelView : INotifyPropertyChanged
    {
        private ObservableCollection<Producto> _Producto;   /*Variable*/

        private ObservableCollection<Producto> Productos   /*Propiedad*/
        {
            get { return this._Producto; }
            set { this._Producto = value; }

        }

        public ProductoModelView ()
        {
            this.Titulo = "Producto";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;
        
    }
}
