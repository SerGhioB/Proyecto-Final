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

    class DetalleFacturaModelView : INotifyPropertyChanged, ICommand
    {
        private bool _IsReadOnlyNumeroFactura = false;
        private bool _IsReadOnlyCodigoProducto = false;
        private bool _IsReadOnlyCantidad = false;
        private bool _IsReadOnlyPrecio = false;
        private bool _IsReadOnlyDescuento = false;
        private string _NumeroFactura;
        private string _CodigoProducto;
        private string _Cantidad;
        private string _Precio;
        private string _Descuento;
        private DetalleFacturaModelView _Instancia;
        private DetalleFactura _SelectDetalleFactura;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();        
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<DetalleFactura> _DetalleFacturas;   /*Variable*/

        public ObservableCollection<DetalleFactura> DetalleFacturas   /*Propiedad*/
        {
            get
            {
                if (this._DetalleFacturas == null)
                {
                    this._DetalleFacturas = new ObservableCollection<DetalleFactura>();
                    foreach (DetalleFactura elemento in db.DetalleFacturas.ToList())
                    {
                        this._DetalleFacturas.Add(elemento);
                    }
                }
                return this._DetalleFacturas;
            }
            set
            {
                this._DetalleFacturas = value;
            }

        }

        public DetalleFactura SelectDetalleFactura
        {
            get
            {
                return this._SelectDetalleFactura;
            }
            set
            {
                if (value != null)
                {
                    this._SelectDetalleFactura = value;
                    this.NumeroFactura = value.NumeroFactura.ToString();
                    this.CodigoProducto = value.CodigoProducto.ToString();
                    this.Cantidad = value.Cantidad.ToString();
                    this.Precio = value.Precio.ToString();
                    this.Descuento = value.ToString();
                    ChangeNotify("SelectDetalleFactura");
                }
            }
        }

        public DetalleFacturaModelView Instancia
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

        public DetalleFacturaModelView()
        {
            this.Titulo = "Detalle Factura";
            this._Instancia = this;
        }
        public string Titulo
        {
            get;
            set;
        }

        public string NumeroFactura
        {
            get
            {
                return _NumeroFactura;
            }
            set
            {
                this._NumeroFactura = value;
                ChangeNotify("NumeroFactura");
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

        public string Descuento
        {
            get
            {
                return _Descuento;
            }
            set
            {
                this._Descuento = value;
                ChangeNotify("Descuento");
            }
        }

        public bool IsReadOnlyNumeroFactura
        {
            get
            {
                return this._IsReadOnlyNumeroFactura;
            }
            set
            {
                this._IsReadOnlyNumeroFactura = value;
                ChangeNotify("IsReadOnlyNumeroFactura");
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

        public bool IsReadOnlyDescuento
        {
            get
            {
                return this._IsReadOnlyDescuento;
            }
            set
            {
                this._IsReadOnlyDescuento = value;
                ChangeNotify("IsReadOnlyDescuento");
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
                DetalleFactura nuevo = new DetalleFactura();
                nuevo.NumeroFactura = Convert.ToInt32(this.NumeroFactura);
                nuevo.CodigoProducto = Convert.ToInt32(this.CodigoProducto);
                nuevo.Cantidad = Convert.ToInt32(this.Cantidad);
                nuevo.Precio = Convert.ToDecimal(this.Precio);
                nuevo.Descuento = Convert.ToDecimal(this.Descuento);
                db.DetalleFacturas.Add(nuevo);
                db.SaveChanges();
                this.DetalleFacturas.Add(nuevo);
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

                int posicion = this.DetalleFacturas.IndexOf(this.SelectDetalleFactura);
                var updateDetalleFactura = this.db.DetalleFacturas.Find(this.SelectDetalleFactura.CodigoDetalle);
                updateDetalleFactura.NumeroFactura = Convert.ToInt32(this.NumeroFactura);
                updateDetalleFactura.CodigoProducto = Convert.ToInt32(this.CodigoProducto);
                updateDetalleFactura.Cantidad = Convert.ToInt32(this.Cantidad);
                updateDetalleFactura.Precio = Convert.ToDecimal(this.Precio);
                updateDetalleFactura.Descuento = Convert.ToDecimal(this.Descuento);
                this.db.Entry(updateDetalleFactura).State = EntityState.Modified;
                this.db.SaveChanges();
                this.DetalleFacturas.RemoveAt(posicion);
                this.DetalleFacturas.Insert(posicion, updateDetalleFactura);
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
                if (this.SelectDetalleFactura != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.DetalleFacturas.Remove(this.SelectDetalleFactura);
                            db.SaveChanges();
                            this.DetalleFacturas.Remove(this.SelectDetalleFactura);
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