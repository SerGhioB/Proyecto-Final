using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProyectoFinal.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;
using System.Windows;


namespace ProyectoFinal.ModelView
{

    enum ACCION /*el nombre de las enumeraciones es en mayusculas*/
    {
        NINGUNO,
        ACTUALIZAR,
        NUEVO,
        GUARDAR
    };

    class CategoriaModelView : INotifyPropertyChanged, ICommand
    {
        #region "Campos"        
        private bool _IsReadOnlyDescripcion = false;        
        private string _Descripcion;
        private CategoriaModelView _Instancia;
        private Categoria _SelectCategoria;                
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        //private ACCION accion = ACCION.NINGUNO;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        private ObservableCollection<Categoria> _Categorias;   /*Variable*/
                                                               /*Esta propiedad permite una consulta en tiempo real hacia la tabla, es decir*/
                                                               /*cualquier modificacion en la tabla lo refleja en la ventana*/

        #endregion

        public ObservableCollection<Categoria> Categorias /*Propiedad*/
        {
            get
            {
                if (this._Categorias == null)
                {
                    this._Categorias = new ObservableCollection<Categoria>();
                    foreach (Categoria elemento in db.Categorias.ToList())
                    {
                        /*Console.WriteLine(elemento.Name);*/
                        this._Categorias.Add(elemento);
                    }
                }
                return this._Categorias;
            }
            set 
            { 
                this._Categorias = value; 
            }
        }

        public Categoria SelectCategoria
        {
            get
            {
                return this._SelectCategoria;
            }
            set
            {
                if (value != null)
                {
                    this._SelectCategoria = value;
                    this.Descripcion = value.Descripcion;
                    ChangeNotify("SelectCategoria");
                }
            }
        }

        public CategoriaModelView Instancia
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

        public CategoriaModelView()
        {
            this.Titulo = "Categorias:";
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
            if (PropertyChanged != null)
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
                Categoria nuevo = new Categoria();
                nuevo.Descripcion = this.Descripcion;
                db.Categorias.Add(nuevo);
                db.SaveChanges();
                this.Categorias.Add(nuevo);
                MessageBox.Show("Registro almacenado");

            }
            /*if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.NUEVO:                       
                        break;
                }
            }*/


            else if (parameter.Equals("Update"))
            {
                
                        int posicion = this.Categorias.IndexOf(this.SelectCategoria);
                        var updateCategoria = this.db.Categorias.Find(this.SelectCategoria.CodigoCategoria);
                        updateCategoria.Descripcion = this.Descripcion;
                        this.db.Entry(updateCategoria).State = EntityState.Modified;
                        this.db.SaveChanges();
                        this.Categorias.RemoveAt(posicion);
                        this.Categorias.Insert(posicion, updateCategoria);
                        MessageBox.Show("Registro actualizado");
                    

                
                //this.accion = ACCION.ACTUALIZAR;                
               
            }

            /*if (parameter.Equals("Save"))
            {
                switch (this.accion)
                {
                    case ACCION.ACTUALIZAR:                       
                        break;
                }
            }*/
                       
            else if (parameter.Equals("Delete"))
            {
                if (this.SelectCategoria != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Categorias.Remove(this.SelectCategoria);
                            db.SaveChanges();
                            this.Categorias.Remove(this.SelectCategoria);
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
