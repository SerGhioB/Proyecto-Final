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
    class FacturaModelView : INotifyPropertyChanged, ICommand
    {

        private string _Nit;
        private string _Fecha;
        private string _Total;
        private bool _IsReadOnlyNit = false;
        private bool _IsReadOnlyFecha = false;
        private bool _IsReadOnlyTotal = false;
        private FacturaModelView _Instancia;
        private Factura _SelectFactura;
        public ProyectoFinalDataContext db = new ProyectoFinalDataContext();
        
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Factura> _Facturas;   /*Variable*/

        public ObservableCollection<Factura> Facturas   /*Propiedad*/
        {
            get
            {
                if (this._Facturas == null)
                {
                    this._Facturas = new ObservableCollection<Factura>();
                    foreach (Factura elemento in db.Facturas.ToList())
                    {
                        this._Facturas.Add(elemento);
                    }
                }
                return this._Facturas;
            }
            set
            {
                this._Facturas = value;
            }
        }

        public Factura SelectFactura
        {
            get
            {
                return this._SelectFactura;
            }
            set
            {
                if (value != null)
                {
                    this._SelectFactura = value;
                    this.Nit = value.Nit;
                    this.Fecha = value.Fecha.ToString();
                    this.Total = value.Total.ToString();
                    ChangeNotify("SelectFactura");
                }
            }
        }

        public FacturaModelView Instancia
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

        public FacturaModelView()
        {
            this.Titulo = "Factura";
            this._Instancia = this;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string Nit
        {
            get
            {
                return _Nit;
            }
            set
            {
                this._Nit = value;
                ChangeNotify("Nit");
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

        public bool IsReadOnlyNit
        {
            get
            {
                return this._IsReadOnlyNit;
            }
            set
            {
                this._IsReadOnlyNit = value;
                ChangeNotify("IsReadOnlyNit");
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
                Factura nuevo = new Factura();
                nuevo.Nit = this.Nit;
                nuevo.Fecha = Convert.ToDateTime(this.Fecha);
                nuevo.Total = Convert.ToDecimal(this.Total);
                db.Facturas.Add(nuevo);
                db.SaveChanges();
                this.Facturas.Add(nuevo);
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

                int posicion = this.Facturas.IndexOf(this.SelectFactura);
                var updateFactura = this.db.Facturas.Find(this.SelectFactura.NumeroFactura);
                updateFactura.Nit = this.Nit;
                updateFactura.Fecha = Convert.ToDateTime(this.Fecha);
                updateFactura.Total = Convert.ToDecimal(this.Total);
                this.db.Entry(updateFactura).State = EntityState.Modified;
                this.db.SaveChanges();
                this.Facturas.RemoveAt(posicion);
                this.Facturas.Insert(posicion, updateFactura);
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
                if (this.SelectFactura != null)
                {
                    var respuesta = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Facturas.Remove(this.SelectFactura);
                            db.SaveChanges();
                            this.Facturas.Remove(this.SelectFactura);
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