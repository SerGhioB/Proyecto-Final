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

    class DetalleCompraModelView : INotifyPropertyChanged, ICommand
    {
        private string _IdCompra;
        private string _CodigoProducto;
        private string _Cantidad;
        private string _Precio;
        private bool _IsReadOnlyIdCompra = false;
        private bool _IsReadOnlyCodigoProducto = false;
        private bool _IsReadOnlyCantidad = false;
        private bool _IsReadOnlyPrecio = false;
        private DetalleCompraModelView _Instancia;
        private DetalleCompra _SelectDetalleCompra;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;


        private ObservableCollection<DetalleCompra> _DetalleCompras;   /*Variable*/

        public ObservableCollection<DetalleCompra> DetalleCompras   /*Propiedad*/
        {
            get
            {
                if (this._DetalleCompras == null)
                {
                    this._DetalleCompras = new ObservableCollection<DetalleCompra>();
                    foreach (DetalleCompra elemento in db.DetalleCompras.ToList()) 
                    {
                        this._DetalleCompras.Add(elemento);
                    }
                }
                return this._DetalleCompras;

            }
            set
            {
                this._DetalleCompras = value;
            }

        }

        public DetalleCompra SelectDetalleCompra
        {
            get
            {
                return this._SelectDetalleCompra;
            }
            set
            {
                if (value != null)
                {
                    this._SelectDetalleCompra = value;
                    this.IdCompra = value.ToString();
                    this.CodigoProducto = value.ToString();
                    this.Cantidad = value.ToString();
                    this.Precio = value.ToString();
                    ChangeNotify("SelectDetalleCompra");

                }
            }
        }

        public DetalleCompraModelView Instancia
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


        public DetalleCompraModelView()
        {
            this.Titulo = "DetalleCompra";
            this._Instancia = this;
        }
        public string Titulo
        {
            get;
            set;
        }
			
		public string IdCompra
        {
            get
            {
                return _IdCompra;
            }
            set
            {
                this._IdCompra = value;
                ChangeNotify("IdCompra");
            }
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

        public string Cantidad
        {
            get
            {
                return _Cantidad;
            }
            set
            {
                this._Cantidad = value;
                ChangeNotify("Cantidad");
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

        public bool IsReadOnlyIdCompra
        {
            get
            {
                return this._IsReadOnlyIdCompra;
            }
            set
            {
                this._IsReadOnlyIdCompra = value;
                ChangeNotify("IsReadOnlyIdCompra");
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

        public bool IsReadOnlyCantidad
        {
            get
            {
                return this._IsReadOnlyCantidad;
            }
            set
            {
                this._IsReadOnlyCantidad = value;
                ChangeNotify("IsReadOnlyCantidad");
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
                DetalleCompra nuevo = new DetalleCompra();
                nuevo.IdCompra = Convert.ToInt32(this.IdCompra);
                nuevo.CodigoProducto = Convert.ToInt32(this.CodigoProducto);
                nuevo.Cantidad = Convert.ToInt32(this.Cantidad);
                nuevo.Precio = Convert.ToDecimal(this.Precio);
                db.DetalleCompras.Add(nuevo);
                db.SaveChanges();
                this.DetalleCompras.Add(nuevo);
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

                int posicion = this.DetalleCompras.IndexOf(this.SelectDetalleCompra);
                var updateDetalleCompra = this.db.DetalleCompras.Find(this.SelectDetalleCompra.IdDetalle);
                updateDetalleCompra.IdCompra = Convert.ToInt32(this.IdCompra);
                updateDetalleCompra.CodigoProducto = Convert.ToInt32(this.CodigoProducto);
                updateDetalleCompra.Cantidad = Convert.ToInt32(this.Cantidad);
                updateDetalleCompra.Precio = Convert.ToDecimal(this.Precio);
                this.db.Entry(updateDetalleCompra).State = EntityState.Modified;
                this.db.SaveChanges();
                this.DetalleCompras.RemoveAt(posicion);
                this.DetalleCompras.Insert(posicion, updateDetalleCompra);
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
                if (this.SelectDetalleCompra != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.DetalleCompras.Remove(this.SelectDetalleCompra);
                            db.SaveChanges();
                            this.DetalleCompras.Remove(this.SelectDetalleCompra);
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