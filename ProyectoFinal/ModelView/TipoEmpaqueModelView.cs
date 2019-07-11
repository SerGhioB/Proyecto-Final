using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProyectoFinal.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Data.Entity;

namespace ProyectoFinal.ModelView
{
    class TipoEmpaqueModelView : INotifyPropertyChanged, ICommand
    {
        private bool _IsReadOnlyDescripcion = false;
        private string _Descripcion;
        private TipoEmpaqueModelView _Instancia;
        private TipoEmpaque _SelectTipoEmpaque;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        private ObservableCollection<TipoEmpaque> _TipoEmpaques;   /*Variable*/

        public ObservableCollection<TipoEmpaque> TipoEmpaques   /*Propiedad*/
        {
            get
            {
                if (this._TipoEmpaques == null)
                {
                    this._TipoEmpaques = new ObservableCollection<TipoEmpaque>();
                    foreach(TipoEmpaque elemento in db.TipoEmpaques.ToList())
                    {
                        this._TipoEmpaques.Add(elemento);
                    }
                }
                return this._TipoEmpaques;
            }
            set
            {
                this._TipoEmpaques = value;
            }

        }

        public TipoEmpaque SelectTipoEmpaque
        {
            get
            {
                return this._SelectTipoEmpaque;
            }
            set
            {
                if (value != null)
                {
                    this._SelectTipoEmpaque = value;
                    this.Descripcion = value.Descripcion;
                    ChangeNotify("SelectTipoEmpaque");
                }

            }
        }

        public TipoEmpaqueModelView Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
            }
        }          
        
        public TipoEmpaqueModelView ()
        {
            this.Titulo = "Tipo Empaque:";
            this._Instancia = this;
        }
        public string Titulo
        {
            get;
            set;
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                this._Descripcion = value;
                ChangeNotify("Descripcion");
            }
        }

        public bool IsReadOnlyDescripcion
        {
            get
            {
                return this._IsReadOnlyDescripcion;
            }
            set
            {
                this._IsReadOnlyDescripcion = value;
                ChangeNotify("IsReadOnlyDescripcion");
            }
        }

        public void ChangeNotify(string propertie)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertie));
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                //MessageBox.Show("Agregar Departamento");                                
                //this.accion = ACCION.NUEVO;  
                TipoEmpaque nuevo = new TipoEmpaque();
                nuevo.Descripcion = this.Descripcion;
                db.TipoEmpaques.Add(nuevo);
                db.SaveChanges();
                this.TipoEmpaques.Add(nuevo);
                MessageBox.Show("Registro almacenado");

            }
            else if (parameter.Equals("Update"))
            {

                int posicion = this.TipoEmpaques.IndexOf(this.SelectTipoEmpaque);
                var updateTipoEmpaque = this.db.TipoEmpaques.Find(this.SelectTipoEmpaque.CodigoEmpaque);
                updateTipoEmpaque.Descripcion = this.Descripcion;
                this.db.Entry(updateTipoEmpaque).State = EntityState.Modified;
                this.db.SaveChanges();
                this.TipoEmpaques.RemoveAt(posicion);
                this.TipoEmpaques.Insert(posicion, updateTipoEmpaque);
                MessageBox.Show("Registro actualizado");
                               
                //this.accion = ACCION.ACTUALIZAR;                
            }
            else if (parameter.Equals("Delete"))
            {
                if (this.SelectTipoEmpaque != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.TipoEmpaques.Remove(this.SelectTipoEmpaque);
                            db.SaveChanges();
                            this.TipoEmpaques.Remove(this.SelectTipoEmpaque);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        MessageBox.Show("Registro eliminado");
                    }
                }

            }

        }
    }
}
