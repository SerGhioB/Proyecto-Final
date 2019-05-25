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
    class CategoriaModelView : INotifyPropertyChanged
    {
        private ObservableCollection<Categoria> _Categoria;   /*Variable*/
                                                                /*Esta propiedad permite una consulta en tiempo real hacia la tabla, es decir*/
                                                                /*cualquier modificacion en la tabla lo refleja en la ventana*/
        private ObservableCollection<Categoria> Categorias   /*Propiedad*/
        {
            get { return this._Categoria; }
            set { this._Categoria = value; }

        }

        public CategoriaModelView()
        {
            this.Titulo = "Categorias:";
        }
        public string Titulo { get; set; }
        public event ProgressChangedEventHandler PropertyChanged;

    }
}
