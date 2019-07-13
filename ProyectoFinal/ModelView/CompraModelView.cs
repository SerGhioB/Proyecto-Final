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

    class CompraModelView : INotifyPropertyChanged, ICommand
    {
        private string _NumeroDocumento;
        private string _CodigoProveedor;
        private string _Fecha;
        private string _Total;
        private bool _IsReadOnlyNumeroDocumento = false;
        private bool _IsReadOnlyCodigoProveedor = false;
        private bool _IsReadOnlyFecha = false;
        private bool _IsReadOnlyTotal = false;
        private CompraModelView _Instancia;
        private Compra _SelectCompra;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Compra> _Compras;   /*Variable*/

        public ObservableCollection<Compra> Compras   /*Propiedad*/
        {
            get
            {
                if (this._Compras == null)
                {
                    this._Compras = new ObservableCollection<Compra>();
                    foreach (Compra elemento in db.Compras.ToList())
                    {
                        this._Compras.Add(elemento);
                    }
                }
                return this._Compras;
            }
            set
            {
                this._Compras = value;
            }
        }

        public Compra SelectCompra
        {
            get
            {
                return this._SelectCompra;
            }
            set
            {
                if (value != null)
                {
                    this._SelectCompra = value;
                    this.NumeroDocumento = value.NumeroDocumento.ToString();
                    this.CodigoProveedor = value.CodigoProveedor.ToString();
                    this.Fecha = value.Fecha.ToString();
                    this.Total = value.Total.ToString();
                    ChangeNotify("SelectCompra");
                }
            }
        }

        public CompraModelView Instancia
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

        public CompraModelView()
        {
            this.Titulo = "Compra";
            this._Instancia = this;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string NumeroDocumento
        {
            get
            {
                return _NumeroDocumento;
            }
            set
            {
                this._NumeroDocumento = value;
                ChangeNotify("NumeroDocumento");
            }
        }

        public string CodigoProveedor
        {
            get
            {
                return _CodigoProveedor;
            }
            set
            {
                this._CodigoProveedor = value;
                ChangeNotify("CodigoProveedor");
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

        public string Total
        {
            get
            {
                return _Total;
            }
            set
            {
                this._Total = value;
                ChangeNotify("Total");
            }
        }

        public bool IsReadOnlyNumeroDocumento
        {
            get
            {
                return this._IsReadOnlyNumeroDocumento;
            }
            set
            {
                this._IsReadOnlyNumeroDocumento = value;
                ChangeNotify("IsReadOnlyNumeroDocumento");
            }
        }

        public bool IsReadOnlyCodigoProveedor
        {
            get
            {
                return this._IsReadOnlyCodigoProveedor;
            }
            set
            {
                this._IsReadOnlyCodigoProveedor = value;
                ChangeNotify("IsReadOnlyCodigoProveedor");
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

        public bool IsReadOnlyTotal
        {
            get
            {
                return this._IsReadOnlyTotal;
            }
            set
            {
                this._IsReadOnlyTotal = value;
                ChangeNotify("IsReadOnlyTotal");
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
                Compra nuevo = new Compra();
                nuevo.NumeroDocumento = Convert.ToInt32(this.NumeroDocumento);
                nuevo.CodigoProveedor = Convert.ToInt32(this.CodigoProveedor);
                nuevo.Fecha = Convert.ToDateTime(this.Fecha);
                nuevo.Total = Convert.ToDecimal(this.Total);
                db.Compras.Add(nuevo);
                db.SaveChanges();
                this.Compras.Add(nuevo);
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

                int posicion = this.Compras.IndexOf(this.SelectCompra);
                var updateCompra = this.db.Compras.Find(this.SelectCompra.IdCompra);
                updateCompra.NumeroDocumento = Convert.ToInt32(this.NumeroDocumento);
                updateCompra.CodigoProveedor = Convert.ToInt32(this.CodigoProveedor);
                updateCompra.Fecha = Convert.ToDateTime(this.Fecha);
                updateCompra.Total = Convert.ToDecimal(this.Total);
                this.db.Entry(updateCompra).State = EntityState.Modified;
                this.db.SaveChanges();
                this.Compras.RemoveAt(posicion);
                this.Compras.Insert(posicion, updateCompra);
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
                if (this.SelectCompra != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Compras.Remove(this.SelectCompra);
                            db.SaveChanges();
                            this.Compras.Remove(this.SelectCompra);
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