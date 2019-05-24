using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProyectoFinal.ModelView
{
    class TipoEmpaqueModelView : INotifyPropertyChanged
    {
        public TipoEmpaqueModelView ()
        {
            this.Titulo = "Tipo Empaque:";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;
    }
}
