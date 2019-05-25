using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProyectoFinal.ModelView
{
    class TelefonoClienteModelView : INotifyPropertyChanged
    {
        public TelefonoClienteModelView()
        {
            this.Titulo = "Telefono Cliente";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;        
    }
}
