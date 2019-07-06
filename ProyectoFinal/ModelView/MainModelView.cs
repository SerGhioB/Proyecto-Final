using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.ModelView;
using System.Windows.Input;
using ProyectoFinal.View;
using System.ComponentModel;


namespace ProyectoFinal.ModelView
{
    public class MainModelView : INotifyPropertyChanged, ICommand
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MainModelView _Instancia;

        public MainModelView Instancia { get; set; }

        public MainModelView()
        {
            this.Instancia = this;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if ( parameter.Equals ("Categoria"))
            {
                new CategoriaView().Show();
            }
        }
    }
}
