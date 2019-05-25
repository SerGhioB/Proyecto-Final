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
    class TipoEmpaqueModelView : INotifyPropertyChanged
    {
        private ObservableCollection<TipoEmpaque> _TipoEmpaque;   /*Variable*/

        private ObservableCollection<TipoEmpaque> TipoEmpaques   /*Propiedad*/
        {
            get { return this._TipoEmpaque; }
            set { this._TipoEmpaque = value; }

        }

        public TipoEmpaqueModelView ()
        {
            this.Titulo = "Tipo Empaque:";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;
    }
}
