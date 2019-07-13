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

   
    class ProductoModelView : INotifyPropertyChanged, ICommand
    {

        private string _CodigoCategoria;
        private string _CodigoEmpaque;
        private string _Descripcion;
        private string _PrecioUnitario;
        private string _PrecioPorMayor;
        private string _PrecioPorDocena;
        private string _Existencia;
        private string _Imagen;
        private bool _IsReadOnlyCodigoCategoria = false;
        private bool _IsReadOnlyCodigoEmpaque = false;
        private bool _IsReadOnlyDescripcion = false;
        private bool _IsReadnOnlyPrecioUnitario = false;
        private bool _IsReadOnlyPrecioPorDocena = false;
        private bool _IsReadOnlyPrecioPorMayor = false;
        private bool _IsReadOnlyExistencia = false;
        private bool _IsReadOnlyImagen = false;
        private ProductoModelView _Instancia;
        private Producto _SelectProducto;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        private ObservableCollection<Producto> _Productos;   /*Variable*/

        public ObservableCollection<Producto> Productos   /*Propiedad*/
        {
            get
            {
                if(this._Productos == null)
                {
                    this._Productos = new ObservableCollection<Producto>();
                    foreach (Producto elemento in db.Productos.ToList())
                    {
                        this._Productos.Add(elemento);
                    }
                }
                return this._Productos;
            }
            set
            {
                this._Productos = value;
            }

        }

        public Producto SelectProducto
        {
            get
            {
                return this._SelectProducto;
            }
            set
            {
                if (value != null)
                {
                    this.SelectProducto = value;
                    this.CodigoCategoria = value.CodigoCategoria.ToString();
                    this.CodigoEmpaque = value.CodigoEmpaque.ToString();
                    this.Descripcion = value.Descripcion;
                    this.PrecioUnitario = value.PrecioUnitario.ToString();                    
                    this.PrecioPorDocena = value.PrecioPorDocena.ToString();
                    this.PrecioPorMayor = value.PrecioPorMayor.ToString();
                    this.Existencia = value.Existencia.ToString();
                    this.Imagen = value.Imagen;
                    ChangeNotify("SelectProducto");
                }
            }
        }

        public ProductoModelView Instancia
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

        public ProductoModelView ()
        {
            this.Titulo = "Producto";
            this._Instancia = this;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string CodigoCategoria
        {
            get
            {
                return _CodigoCategoria;
            }
            set
            {
                this._CodigoCategoria = value;
                ChangeNotify("CodigoCategoria");
            }
        }


        public string CodigoEmpaque
        {
            get
            {
                return _CodigoEmpaque;
            }
            set
            {
                this._CodigoEmpaque = value;
                ChangeNotify("CodigoEmpaque");
            }
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

        public string PrecioUnitario
        {
            get
            {
                return _PrecioUnitario;
            }
            set
            {
                this._PrecioUnitario = value;
                ChangeNotify("PrecioUnitario");
            }
        }

        public string PrecioPorDocena
        {
            get
            {
                return _PrecioPorDocena;
            }
            set
            {
                this._PrecioPorDocena = value;
                ChangeNotify("PrecioPorDocena");
            }
        }

        public string PrecioPorMayor
        {
            get
            {
                return _PrecioPorMayor;
            }
            set
            {
                this._PrecioPorMayor = value;
                ChangeNotify("PrecioPorMayor");
            }
        }

        public string Existencia
        {
            get
            {
                return _Existencia;
            }
            set
            {
                this._Existencia = value;
                ChangeNotify("Existencia");
            }
        }

        public string Imagen
        {
            get
            {
                return _Imagen;
            }
            set
            {
                this._Imagen = value;
                ChangeNotify("Imagen");
            }
        }

        public bool IsReadOnlyCodigoCategoria
        {
            get
            {
                return this._IsReadOnlyCodigoCategoria;
            }
            set
            {
                this._IsReadOnlyCodigoCategoria = value;
                ChangeNotify("IsReadOnlyCodigoCategoria");
            }
        }

        public bool IsReadOnlyCodigoEmpaque
        {
            get
            {
                return this._IsReadOnlyCodigoEmpaque;
            }
            set
            {
                this._IsReadOnlyCodigoEmpaque = value;
                ChangeNotify("IsReadOnlyCodigoEmpaque");
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

        public bool IsReadOnlyPrecioUnitario
        {
            get
            {
                return this._IsReadnOnlyPrecioUnitario;
            }
            set
            {
                this._IsReadnOnlyPrecioUnitario = value;
                ChangeNotify("IsReadOnlyPrecioUnitario");
            }
        }

        public bool IsReadOnlyPrecioPorDocena
        {
            get
            {
                return this._IsReadOnlyPrecioPorDocena;
            }
            set
            {
                this._IsReadOnlyPrecioPorDocena = value;
                ChangeNotify("IsReadOnlyPrecioPorDocena");
            }
        }

        public bool IsReadOnlyPrecioPorMayor
        {
            get
            {
                return this._IsReadOnlyPrecioPorMayor;
            }
            set
            {
                this._IsReadOnlyPrecioPorMayor = value;
                ChangeNotify("IsReadOnlyPrecioPorMayor");
            }
        }

        public bool IsReadOnlyExistencia
        {
            get
            {
                return this._IsReadOnlyExistencia;
            }
            set
            {
                this._IsReadOnlyExistencia = value;
                ChangeNotify("IsReadOnlyExistencia");
            }
        }

        public bool IsReadOnlyImagen
        {
            get
            {
                return this._IsReadOnlyImagen;
            }
            set
            {
                this._IsReadOnlyImagen = value;
                ChangeNotify("IsReadOnlyImagen");
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
                Producto nuevo = new Producto();
                nuevo.CodigoCategoria = Convert.ToInt32(this.CodigoCategoria);
                nuevo.CodigoEmpaque = Convert.ToInt32(this.CodigoEmpaque);
                nuevo.Descripcion = this.Descripcion;
                nuevo.PrecioUnitario = Convert.ToDecimal(this.PrecioUnitario);
                nuevo.PrecioPorDocena = Convert.ToDecimal(this.PrecioPorDocena);
                nuevo.PrecioPorMayor = Convert.ToDecimal(this.PrecioPorMayor);
                nuevo.Existencia = Convert.ToInt32(this.Existencia);
                nuevo.Imagen = this.Imagen;
                db.Productos.Add(nuevo);
                db.SaveChanges();
                this.Productos.Add(nuevo);
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

                int posicion = this.Productos.IndexOf(this.SelectProducto);
                var updateProducto = this.db.Productos.Find(this.SelectProducto.CodigoProducto);                
                updateProducto.CodigoCategoria = Convert.ToInt32(this.CodigoCategoria);
                updateProducto.CodigoEmpaque = Convert.ToInt32(this.CodigoEmpaque);
                updateProducto.Descripcion = this.Descripcion;
                updateProducto.PrecioUnitario = Convert.ToDecimal(this.PrecioUnitario);
                updateProducto.PrecioPorDocena = Convert.ToDecimal(this.PrecioPorDocena);
                updateProducto.PrecioPorMayor = Convert.ToDecimal(this.PrecioPorMayor);
                updateProducto.Existencia = Convert.ToInt32(this.Existencia);
                updateProducto.Imagen = this.Imagen;
                this.db.Entry(updateProducto).State = EntityState.Modified;
                this.db.SaveChanges();
                this.Productos.RemoveAt(posicion);
                this.Productos.Insert(posicion, updateProducto);
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
                if (this.SelectProducto != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Productos.Remove(this.SelectProducto);
                            db.SaveChanges();
                            this.Productos.Remove(this.SelectProducto);
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
