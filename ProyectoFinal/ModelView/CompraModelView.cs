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
    class CompraModelView : INotifyPropertyChanged
    {

        private ObservableCollection<Compra> _Compra;   /*Variable*/

        private ObservableCollection<Compra> Compras   /*Propiedad*/
        {
            get { return this._Compra; }
            set { this._Compra = value; }

        }

        public CompraModelView()
        {
            this.Titulo = "Compra";
        }
        public string Titulo {get; set;}
        public event ProgressChangedEventHandler PropertyChanged;

    }
}
