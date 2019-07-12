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

    class InventarioModelView : INotifyPropertyChanged, ICommand
    {

        private string _CodigoProducto;
        private string _Fecha;
        private string _TipoRegistro;
        private string _Precio;
        private string _Entradas;
        private string _Salidas;
        private bool _IsReadOnlyCodigoProducto = false;
        private bool _IsReadOnlyFecha = false;
        private bool _IsReadOnlyTipoRegistro = false;
        private bool _IsReadOnlyPrecio = false;
        private bool _IsReadOnlyEntradas = false;
        private bool _IsReadOnlySalidas = false;
        private InventarioModelView _Instancia;
        private Inventario _SelectInventario;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        private ObservableCollection<Inventario> _Inventarios;   /*Variable*/

        public ObservableCollection<Inventario> Inventarios   /*Propiedad*/
        {
            get
            {
                if (this._Inventarios == null)
                {
                    this._Inventarios = new ObservableCollection<Inventario>();
                    foreach (Inventario elemento in db.Inventarios.ToList())
                    {
                        this._Inventarios.Add(elemento);
                    }
                }
                return this._Inventarios;
            }
            set
            {
                this._Inventarios = value;
            }
        }

        public Inventario SelectInventario
        {
            get
            {
                return this._SelectInventario;
            }
            set
            {
                if (value != null)
                {
                    this._SelectInventario = value;
                    this.CodigoProducto = value.CodigoProducto.ToString();
                    this.Fecha = value.Fecha.ToString();
                    this.TipoRegistro = value.TipoRegistro; 
                    this.Precio = value.Precio.ToString();
                    this.Entradas = value.Entradas.ToString();
                    this.Salidas = value.Salidas.ToString();
                    ChangeNotify("SelectInventario");
                }
            }
        }

        public InventarioModelView Instancia
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

        public InventarioModelView()
        {
            this.Titulo = "Inventario";
            this._Instancia = this;
        }
        public string Titulo
        {
            get;
            set;
        }

        public string CodigoProducto
        {
            get
            {
                return _CodigoProducto;
            }
            set
            {
                this._CodigoProducto = value;
                ChangeNotify("CodigoProducto");
            }
        }

        public string Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                this._Fecha = value;
                ChangeNotify("Fecha");
            }
        }

        public string TipoRegistro
        {
            get
            {
                return _TipoRegistro;
            }
            set
            {
                this._TipoRegistro = value;
                ChangeNotify("TipoRegistro");
            }
        }

        public string Precio
        {
            get
            {
                return _Precio;
            }
            set
            {
                this._Precio = value;
                ChangeNotify("Precio");
            }
        }

        public string Entradas
        {
            get
            {
                return _Entradas;
            }
            set
            {
                this._Entradas = value;
                ChangeNotify("Entradas");
            }
        }

        public string Salidas
        {
            get
            {
                return _Salidas;
            }
            set
            {
                this._Salidas = value;
                ChangeNotify("Salidas");
            }
        }
          

        public bool IsReadOnlyCodigoProducto
        {
            get
            {
                return this._IsReadOnlyCodigoProducto;
            }
            set
            {
                this._IsReadOnlyCodigoProducto = value;
                ChangeNotify("IsReadOnlyCodigoProducto");
            }
        }

        public bool IsReadOnlyFecha
        {
            get
            {
                return this._IsReadOnlyFecha;
            }
            set
            {
                this._IsReadOnlyFecha = value;
                ChangeNotify("IsReadOnlyFecha");
            }
        }

        public bool IsReadOnlyTipoRegistro
        {
            get
            {
                return this._IsReadOnlyTipoRegistro;
            }
            set
            {
                this._IsReadOnlyTipoRegistro = value;
                ChangeNotify("IsReadOnlyTipoRegistro");
            }
        }

        public bool IsReadOnlyPrecio
        {
            get
            {
                return this._IsReadOnlyPrecio;
            }
            set
            {
                this._IsReadOnlyPrecio = value;
                ChangeNotify("IsReadOnlyPrecio");
            }
        }

        public bool IsReadOnlyEntradas
        {
            get
            {
                return this._IsReadOnlyEntradas;
            }
            set
            {
                this._IsReadOnlyEntradas = value;
                ChangeNotify("IsReadOnlyEntradas");
            }
        }

        public bool IsReadOnlySalidas
        {
            get
            {
                return this._IsReadOnlySalidas;
            }
            set
            {
                this._IsReadOnlySalidas = value;
                ChangeNotify("IsReadOnlySalidas");
            }
        }

        private void ChangeNotify(string propertie)
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
                Inventario nuevo = new Inventario();
                nuevo.CodigoProducto = Convert.ToInt32(this.CodigoProducto);
                nuevo.Fecha = Convert.ToDateTime(this.Fecha);
                nuevo.TipoRegistro = this.TipoRegistro;
                nuevo.Precio = Convert.ToDecimal(this.Precio);
                nuevo.Entradas = Convert.ToInt32(this.Entradas);
                nuevo.Salidas = Convert.ToInt32(this.Salidas);
                db.Inventarios.Add(nuevo);
                db.SaveChanges();
                this.Inventarios.Add(nuevo);
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
                int posicion = this.Inventarios.IndexOf(this.SelectInventario);
                var updateInventario = this.db.Inventarios.Find(this.SelectInventario.CodigoInventario);
                updateInventario.CodigoProducto = Convert.ToInt32(this.CodigoProducto);
                updateInventario.Fecha = Convert.ToDateTime(this.Fecha);
                updateInventario.TipoRegistro = this.TipoRegistro;
                updateInventario.Precio = Convert.ToDecimal(this.Precio);
                updateInventario.Entradas = Convert.ToInt32(this.Entradas);
                updateInventario.Salidas = Convert.ToInt32(this.Salidas);
                this.db.Entry(updateInventario).State = EntityState.Modified;
                this.db.SaveChanges();
                this.Inventarios.RemoveAt(posicion);
                this.Inventarios.Insert(posicion, updateInventario);
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
                if (this.SelectInventario != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Inventarios.Remove(this.SelectInventario);
                            db.SaveChanges();
                            this.Inventarios.Remove(this.SelectInventario);
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