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
    class InventarioModelView : INotifyPropertyChanged
    {
        private ObservableCollection<Inventario> _Inventario;   /*Variable*/

        private ObservableCollection<Inventario> Inventarios   /*Propiedad*/
        {
            get { return this._Inventario; }
            set { this._Inventario = value; }

        }

        public InventarioModelView ()
        {
            this.Titulo = "Inventario";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;        
    }
}
